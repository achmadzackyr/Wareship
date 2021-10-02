using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Auth
{
    public class RegisterResponseModel
    {
        public Status Status { get; set; }
        public ResultRegister Result { get; set; } 
    }

    public class ResultRegister
    {
        public string Message { get; set; }
        public UserDTO User { get; set; }
        public List<string> Roles { get; set; }
    }
}
