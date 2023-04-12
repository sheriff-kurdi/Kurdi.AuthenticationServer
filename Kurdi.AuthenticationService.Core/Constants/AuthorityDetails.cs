
using System.Collections.Generic;

namespace Kurdi.AuthenticationService.Core.Constants
{
    public static class AuthorityDetails
    {
        public static readonly List<string> Actions = new List<string>{
            "CREATE",
            "READ",
            "EDIT",
            "DELETE"
        };

        //TODO:get them from database , eatch project will comunicate must be aded him self to database, authorize app from his url, port
        public static readonly List<string> ProjectsIdentifier = new List<string>{
            "INVENTORY",
            "ORDERS",
            "PURCHASING"
        };
    }
}