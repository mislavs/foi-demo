using System;
using System.ComponentModel.DataAnnotations;

namespace FoiDemo.Data.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        public DateTime? DeletionTime { get; set; }
    }
}
