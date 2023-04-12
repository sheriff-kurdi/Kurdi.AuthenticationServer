using System.ComponentModel.DataAnnotations.Schema;


namespace Kurdi.AuthenticationService.Core.Entities
{
    public class Module
    {
        [Column(name: "projects_identifier")]
        public string ProjectsIdentifier { get; set; }
        [ForeignKey("ProjectsIdentifier")]
        public Project Project { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }
    }
}