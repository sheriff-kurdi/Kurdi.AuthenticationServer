using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kurdi.AuthenticationService.Core.Entities
{
    public class Action
    {
        [Key]
        public int Id { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }
    }
}