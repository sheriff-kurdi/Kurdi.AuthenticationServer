using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kurdi.AuthenticationService.Core.Exceptions
{
    public class InvalidPasswordException : Exception
    {

        public InvalidPasswordException() : base(String.Format("Invalid Password"))
        {

        }
    }
}
