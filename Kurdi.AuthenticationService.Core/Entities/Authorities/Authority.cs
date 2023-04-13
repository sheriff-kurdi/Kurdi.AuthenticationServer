using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.AuthenticationService.Core.Entities.Authorities
{
    public class Authority
    {
        public string ProjectsIdentifier { get; set; }
        public Project Project { get; set; }
        public string ModuleName { get; set; }
        public Module Module { get; set; }

        public string ActionName { get; set; }
        public Action Action { get; set; }
        public string GetAuthority()
        {
            return $"{this.ProjectsIdentifier}:{this.ModuleName}:{this.ActionName}";
        }

    }
}