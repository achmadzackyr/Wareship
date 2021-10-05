using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wareship.ViewModel.Global;

namespace Wareship.ViewModel.Auth
{
    public class MeResponseModel
    {
        public Status Status { get; set; }
        public ResultMe Result { get; set; }
    }

    public class ResultMe
    {
        public UserDTO User { get; set; }
        public List<string> Roles { get; set; }
    }
}
