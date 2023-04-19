using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.AuthenticationService.Core.Entities
{
    public class AggregateRoot
    {
        [Key]
        [Column(name: "id")]
        public int Id { get; set; }
        public TimeStamps TimeStamps { get; set; }
    }
}
