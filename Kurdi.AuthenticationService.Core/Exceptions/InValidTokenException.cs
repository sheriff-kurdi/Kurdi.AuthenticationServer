using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kurdi.ECommerce.Inventory.Core.Exceptions
{
    public class InValidTokenException : Exception
    {
        
        public InValidTokenException() : base(String.Format("This token is invalid"))
        {

        }
    }
}
