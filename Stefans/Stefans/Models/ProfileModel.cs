using System.ComponentModel.DataAnnotations;
using UM;
using Res = General.Properties.Resources;

namespace Stefans.Models
{
    public class ProfileModel
    {
        public AccountModel AccountModel { get; set; }
        public ChangePasswordModel PasswordModel { get; set; }
    }

    public class AccountModel
    {
        public AccountModel()
        {
            
        }

        public AccountModel(User User)
        {
            Address1 = User.Address1;
            Address2 = User.Address2;
            City = User.City;
            FirstName = User.FirstName;
            LastName = User.LastName;
            Phone = User.Phone;
            StateID = User.StateID;
            Zip = User.Zip;
        }

        [Required]
        [StringLength(100)]
        public string FirstName { set; get; }

        [Required]
        [StringLength(100)]
        public string LastName { set; get; }

        [StringLength(50)]
        public string Phone { set; get; }

        [StringLength(200)]
        public string Address1 { set; get; }

        [StringLength(200)]
        public string Address2 { set; get; }

        public int? StateID { set; get; }

        [StringLength(5)]
        [RegularExpression("[0-9]+$", ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorZipNumeric")]
        public string Zip { set; get; }
        
        [StringLength(100)]
        public string City { set; get; }

        public bool IsValid { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required]
        public string OriginalPassword { get; set; }
        [Required]
        [StringLength(200)]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public bool IsValid { get; set; }
    }
}