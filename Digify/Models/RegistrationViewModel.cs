using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Digify.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string companyName { get;set; }
        [Required]
        public string npwp { get;set; }
        [Required] 
        
        public string directorName { get;set; }
        [Required]
        public string picName { get;set; }
        [Required]
        public string email { get;set; }
        [Required]
        public string phone { get;set; }
     
        [Required]
        public IFormFile npwpFile { get; set; }

        [Required]
        public IFormFile poaFile { get; set; }

    }
}
