using System.ComponentModel.DataAnnotations.Schema;


namespace Kurdi.AuthenticationService.Core.Entities.Authorities
{
    public class Module
    {
        public string ProjectIdentifier { get; set; }
        public Project Project { get; set; }
        public string Name { get; set; }
    }
}