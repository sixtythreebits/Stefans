using System.ComponentModel.DataAnnotations;

namespace Stefans.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string OriginalPassword { get; set; }
        [Required]
        [StringLength(200)]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}