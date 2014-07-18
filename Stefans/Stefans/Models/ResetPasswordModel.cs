using System.ComponentModel.DataAnnotations;

namespace Stefans.Models
{
    public class ResetPasswordModel
    {
        [Required]
        [StringLength(200)]
        public string Password { get; set; }
        [Required]
        [StringLength(200)]
        public string ConfirmPassword { get; set; }

        public string AdditionalData { get; set; }
    }
}