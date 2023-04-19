using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.AuthenticationService.Core.VM
{
    public class RemoveAuthorityFromUserVM
    {
        public string UserId { get; set; }
        public string ProjectIdentifier { get; set; }
        public string ModuleName { get; set; }
        public string ActionName { get; set; }
    }
}