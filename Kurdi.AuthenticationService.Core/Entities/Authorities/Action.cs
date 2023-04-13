using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kurdi.AuthenticationService.Core.Entities.Authorities
{
    public class Action
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}