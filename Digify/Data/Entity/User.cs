using System.ComponentModel.DataAnnotations;

namespace Digify.Data.Entity
{
    public partial class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string companyName { get; set; }
        [Required]
        public string npwp { get; set; }
        [Required]

        public string directorName { get; set; }
        [Required]
        public string picName { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string npwpPath { get; set; }
        public string poaPath { get; set; }
    }
}
