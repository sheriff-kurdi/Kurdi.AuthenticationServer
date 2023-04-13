using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kurdi.AuthenticationService.Core.Entities.Authorities
{
    public class Project
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public ICollection<Authority> Authorities { get; set; } = new List<Authority>();
    }
}