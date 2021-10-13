using Wareship.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Wareship.ViewModel.Global;
using Wareship.ViewModel.Auth;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Wareship.Model.Users;

namespace Wareship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var stat = new Status();
            var resu = new ResultLogin();

            var resp = new LoginResponseModel();

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await userManager.GetRolesAsync(user);
                    var roleList = new List<string>();

                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        roleList.Add(userRole);
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    stat.ResponseCode = StatusCodes.Status200OK;
                    stat.ResponseMessage = "Success";

                    resu.Message = "Login Successfully!";
                    resu.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    resu.Expiration = token.ValidTo;

                    // var userAddress = _context.UserAddress.Where();

                    resu.User = new UserDTO
                    {
                        // City = user.City,
                        Email = user.Email,
                        Name = user.Name,
                        // Phone = user.Phone,
                        ProfilePictureUrl = user.ProfilePictureUrl,
                        //Province = user.Province,
                        //Street = user.Street,
                        //Subdistrict = user.Subdistrict,
                        //ZipCode = user.ZipCode,
                        UserName = user.UserName,
                        UserStatusId = user.UserStatusId,
                        UserTierId = user.UserTierId,
                        JoinDate = user.CreatedAt,
                        JoinDateString = user.CreatedAt.ToString("dd-MM-yyyy")
                    };
                    resu.Roles = roleList;

                    resp.Status = stat;
                    resp.Result = resu;

                    return Ok(resp);
                }
                stat.ResponseCode = StatusCodes.Status401Unauthorized;
                stat.ResponseMessage = "Error";

                resu.Message = "Unauthorized";
                resu.Token = null;

                resp.Status = stat;
                resp.Result = resu;

                return Unauthorized(resp);
            } else
            {
                stat.ResponseCode = StatusCodes.Status400BadRequest;
                stat.ResponseMessage = "Error";

                resu.Message = "Bad Request";
                resu.Token = null;

                resp.Status = stat;
                resp.Result = resu;
                return BadRequest(resp);
            }
        }

        //[Authorize]
        //[HttpPost]
        //[Route("logout")]
        //public async Task<IActionResult> Logout([FromBody] string token)
        //{
            
        //}

        //Register dropshipper
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            var stat = new Status();
            var resu = new ResultRegister();

            var resp = new RegisterResponseModel();
            if (ModelState.IsValid)
            {
                var userExists = await userManager.FindByNameAsync(model.Username);
                if (userExists != null)
                {
                    stat.ResponseCode = StatusCodes.Status500InternalServerError;
                    stat.ResponseMessage = "Error";

                    resu.User = null;
                    resu.Message = "Username already registered";

                    resp.Status = stat;
                    resp.Result = resu;

                    return StatusCode(StatusCodes.Status500InternalServerError, resp);
                }

                ApplicationUser user = new()
                {
                    //Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    //Name = model.Name,
                    //Dob = model.Dob,
                    //Gender = model.Gender,
                    //Street = model.Street,
                    //Subdistrict = model.Subdistrict,
                    //City = model.City,
                    //Province = model.Province,
                    //PhoneNumber = model.PhoneNumber,
                    //ProfilePictureUrl = model.ProfilePictureUrl,
                    CreatedAt = DateTime.Now,
                    CreatedBy = model.CreatedBy,
                    UserStatusId = 1,
                    UserTierId = 1
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    stat.ResponseCode = StatusCodes.Status500InternalServerError;
                    stat.ResponseMessage = "Error";

                    resu.User = null;
                    //resu.Message = "User creation failed! Please check user details and try again.";
                    foreach(var x in result.Errors)
                    {
                        resu.Message += x.Description;
                    }
                    resp.Status = stat;
                    resp.Result = resu;

                    return StatusCode(StatusCodes.Status500InternalServerError, resp);
                }

                // foreach (var role in model.RoleNames) {
                    try
                    {
                        await userManager.AddToRoleAsync(user, "Dropshipper");
                    } catch
                    {
                        stat.ResponseCode = StatusCodes.Status500InternalServerError;
                        stat.ResponseMessage = "Roles not exist";

                        resu.User = null;
                        resp.Status = stat;
                        resp.Result = resu;

                        await userManager.DeleteAsync(user);
                        return StatusCode(StatusCodes.Status500InternalServerError, resp);
                    }
                // }

                var address = new Address
                {
                    Name = model.Username,
                    CityId = model.CityId,
                    City = model.City,
                    ProvinceId = model.ProvinceId,
                    Province = model.Province
                };

                _context.Address.Add(address);
                await _context.SaveChangesAsync();

                var userAddress = new UserAddress
                {
                    AddressId = address.Id,
                    UserId = user.Id,
                    Role = "Rumah"
                };

                _context.UserAddress.Add(userAddress);
                await _context.SaveChangesAsync();

                var newUser = new UserDTO
                {
                    City = address.City,
                    CityId = address.CityId,
                    Province = address.Province,
                    ProvinceId = address.ProvinceId,
                    //Email = user.Email,
                    //Name = user.Name,
                    //Phone = user.Phone,
                    //ProfilePictureUrl = user.ProfilePictureUrl,
                    //Street = user.Street,
                    //Subdistrict = user.Subdistrict,
                    //ZipCode = user.ZipCode,
                    UserName = user.UserName,
                    UserStatusId = user.UserStatusId,
                    UserTierId = user.UserTierId,
                    JoinDate = user.CreatedAt,
                    JoinDateString = user.CreatedAt.ToString("dd-mm-yyyy")
                };

                stat.ResponseCode = StatusCodes.Status200OK;
                stat.ResponseMessage = "Success";

                resu.User = newUser;
                resu.Message = "User created successfully!";
                resu.Roles = model.RoleNames;

                resp.Status = stat;
                resp.Result = resu;

                return Ok(resp);
            } else
            {
                stat.ResponseCode = StatusCodes.Status400BadRequest;
                stat.ResponseMessage = "Error";

                resu.Message = "Bad Request";
                resu.User = null;

                resp.Status = stat;
                resp.Result = resu;
                return BadRequest(resp);
            }
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequestModel model)
        {
            var stat = new Status();
            var resu = new ResultRegister();

            var resp = new RegisterResponseModel();

            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                stat.ResponseCode = StatusCodes.Status500InternalServerError;
                stat.ResponseMessage = "Error";

                resu.User = null;
                resu.Message = "User already exists!";

                resp.Status = stat;
                resp.Result = resu;

                return StatusCode(StatusCodes.Status500InternalServerError, resp);
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                stat.ResponseCode = StatusCodes.Status500InternalServerError;
                stat.ResponseMessage = "Error";

                resu.User = null;
                resu.Message = "User creation failed! Please check user details and try again.";

                resp.Status = stat;
                resp.Result = resu;

                return StatusCode(StatusCodes.Status500InternalServerError, resp);
            }

            await userManager.AddToRoleAsync(user, UserRoles.Admin);

            var newUser = new UserDTO
            {
                //City = user.City,
                Email = user.Email,
                Name = user.Name,
                //Phone = user.Phone,
                ProfilePictureUrl = user.ProfilePictureUrl,
                //Province = user.Province,
                //Street = user.Street,
                //Subdistrict = user.Subdistrict,
                //ZipCode = user.ZipCode,
                UserName = user.UserName,
                UserStatusId = user.UserStatusId,
                UserTierId = user.UserTierId
            };

            stat.ResponseCode = StatusCodes.Status200OK;
            stat.ResponseMessage = "Success";

            resu.User = newUser;
            resu.Message = "User created successfully!";

            resp.Status = stat;
            resp.Result = resu;
            return Ok(resp);
        }

        [Authorize]
        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> GetByToken()
        {
            var stat = new Status();
            var resu = new ResultMe();

            var resp = new MeResponseModel();
            var roleList = new List<string>();

            string Username = User.FindFirst(ClaimTypes.Name)?.Value;

            var user = await userManager.FindByNameAsync(Username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, Username);
            }

            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                roleList.Add(role);
            }

            var address = await _context.UserAddress
                .Include(u => u.Address)
                .AsSplitQuery()
                .OrderBy(u => u.Id)
                .SingleAsync(u => u.UserId == user.Id);

            stat.ResponseCode = StatusCodes.Status200OK;
            stat.ResponseMessage = "Success";

            resu.User = new UserDTO
            {
                Email = user.Email,
                Name = user.Name,
                CityId = address.Address.CityId,
                City = address.Address.City,
                Phone = address.Address.Phone,
                ProfilePictureUrl = user.ProfilePictureUrl,
                ProvinceId = address.Address.ProvinceId,
                Province = address.Address.Province,
                Street = address.Address.Street,
                SubdistrictId = address.Address.SubdistrictId,
                Subdistrict = address.Address.Subdistrict,
                ZipCode = address.Address.ZipCode,
                UserName = user.UserName,
                UserStatusId = user.UserStatusId,
                UserTierId = user.UserTierId,
                JoinDate = user.CreatedAt,
                JoinDateString = user.CreatedAt.ToString("dd-MM-yyyy")
            };
            resu.Roles = roleList;

            resp.Status = stat;
            resp.Result = resu;

            return Ok(resp);
        }
    }
}
