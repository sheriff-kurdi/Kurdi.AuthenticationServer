using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.AuthenticationService.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Kurdi.AuthenticationService.Core.Entities
{
    [Table(name: "authorities")]
    public class Authority
    {
        [Column(name: "projects_identifier")]
        public string ProjectsIdentifier { get; set; }
        public Project Project { get; set; }

        [Column(name: "module_name")]
        public string ModuleName { get; set; }
        [ForeignKey("ModuleName")]
        public Module Module { get; set; }

        [Column(name: "action")]
        public string Action { get; set; }

        public string GetAuthority()
        {
            return $"{this.ProjectsIdentifier}:{this.ModuleName}:{this.Action}";
        }

    }
}