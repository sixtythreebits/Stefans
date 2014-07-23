using System.ComponentModel.DataAnnotations;
using Core.UM;

namespace Stefans.Models
{
    public class RegistrationModel
    {
        public User User { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}