using System.ComponentModel.DataAnnotations;

namespace LMSystemUI.Models
{
	public class CreateClientModel
	{
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(500)]
        public string ClientAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClientPhoneNumber { get; set; }
        [MaxLength(250)]
        public string ClientEMail { get; set; }
    }
}

