using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.AuthenticationService.Core.Entities.Authorities;
using Microsoft.AspNetCore.Identity;

namespace Kurdi.AuthenticationService.Core.Entities
{
    [Table(name: "users")]
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Authority> Authorities { get; set; } = new List<Authority>();

        public static implicit operator List<object>(User v)
        {
            throw new NotImplementedException();
        }
    }
}