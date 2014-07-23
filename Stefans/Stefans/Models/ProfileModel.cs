using System.ComponentModel.DataAnnotations;
using Core.UM;
using Res = Core.Properties.Resources;

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

        [Display(Name = "First Name")]
        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string FirstName { set; get; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string LastName { set; get; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(50, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string Phone { set; get; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(200, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string Address1 { set; get; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(200, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string Address2 { set; get; }

        [Display(Name = "State")]
        [Required]
        public int? StateID { set; get; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression("[0-9]+$", ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorZipNumeric")]
        [StringLength(5, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string Zip { set; get; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(100, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string City { set; get; }
    }

    public class ChangePasswordModel
    {
        [Display(Name = "Original Password")]
        [Required]
        public string OriginalPassword { get; set; }

        [Display(Name = "New Password")]
        [Required]
        [StringLength(200, ErrorMessageResourceType = typeof(Res), ErrorMessageResourceName = "ErrorMaxLength")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirm Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}