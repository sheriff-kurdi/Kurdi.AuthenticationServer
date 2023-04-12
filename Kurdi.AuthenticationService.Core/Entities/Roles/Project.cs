using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.AuthenticationService.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Kurdi.AuthenticationService.Core.Entities
{
    [Table(name: "projects")]
    public class Project
    {
        [Key]
        public string Id { get; set; }
        
        [Column(name: "description")]
        public string Description { get; set; }

        [Column(name: "action")]
        public string Action { get; set; }

    }
}