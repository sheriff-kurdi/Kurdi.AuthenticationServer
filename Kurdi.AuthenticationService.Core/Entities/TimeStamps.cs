using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.AuthenticationService.Core.Entities
{
    [Owned]
    public class TimeStamps
    {
        [Column(name: "created_at")]
        public DateTime CreatedAt { get; set; }
        [Column(name: "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [Column(name: "deleted_at")]
        public DateTime DeletedAt { get; set; }
    }
}