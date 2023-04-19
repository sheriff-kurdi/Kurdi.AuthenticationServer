using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kurdi.AuthenticationService.Core.Exceptions
{
    public class AuthorityNotFoundException : Exception
    {

        public AuthorityNotFoundException() : base(String.Format("Authority not found"))
        {

        }
    }
}
