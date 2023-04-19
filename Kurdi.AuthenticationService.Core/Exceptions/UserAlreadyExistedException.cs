using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kurdi.AuthenticationService.Core.Exceptions
{
    public class UserAlreadyExistedException : Exception
    {

        public UserAlreadyExistedException() : base(String.Format("User Already Existed"))
        {

        }
    }
}
