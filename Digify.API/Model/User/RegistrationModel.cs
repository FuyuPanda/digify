using System.ComponentModel.DataAnnotations;

namespace Digify.API.Model.User
{
    public class RegistrationModel
    {
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
        public string phone { get; set; }

        [Required]
        public string npwpFile { get; set; }

        [Required]
        public string poaFile { get; set; }

    }
}
