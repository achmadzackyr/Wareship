using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Auth
{
    public class LoginResponseModel
    {
        public Status Status { get; set; }
        public ResultLogin Result { get; set; }
    }

    public class ResultLogin
    {
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserDTO User { get; set; }
    }
}
