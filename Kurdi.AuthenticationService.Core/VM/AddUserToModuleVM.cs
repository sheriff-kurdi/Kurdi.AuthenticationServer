using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.AuthenticationService.Core.VM
{
    public class AddUserToModuleVM
    {
        public string UserId { get; set; }
        public string ProjectIdentifier { get; set; }
        public string ModuleName { get; set; }
    }
}