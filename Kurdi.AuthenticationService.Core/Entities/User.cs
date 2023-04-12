using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Kurdi.AuthenticationService.Core.Entities
{
    [Table(name: "users")]
    public class User : IdentityUser
    {
        [Column(name: "first_name")]
        public string FirstName { get; set; }
        [Column(name: "last_name")]
        public string LastName { get; set; }


    }
}