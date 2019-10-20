using System.ComponentModel.DataAnnotations;

namespace FoiDemo.Data.Models
{
    public class Client : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
