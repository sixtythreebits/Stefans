using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Core.CM;
using Core.Properties;
using Core.UM;

namespace Stefans.Models
{
    public class CheckoutModel
    {
        public CheckoutModel()
        {
            
        }

        public CheckoutModel(User User)
        {
            Billing = Shipping = new AddressModel
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                Address1 = User.Address1,
                Address2 = User.Address2,
                City = User.City,
                Phone = User.Phone,
                StateID = User.StateID,
                Zip = User.Zip
            };

            Card = new CardModel
            {
                FirstName = User.FirstName,
                LastName = User.LastName
            };
        }

        public CardModel Card { get; set; }

        public AddressModel Billing { get; set; }

        public AddressModel Shipping { get; set; }

        public List<CartItem> CartItems { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }
    }

    public class AddressModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Address Line 1")]
        [Required]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        [Required]
        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required]
        public int? StateID { set; get; }

        [Required]
        [RegularExpression("[0-9]+$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorNumeric")]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMaxLength")]
        public string Zip { set; get; }

        [Required]
        public string Phone { set; get; }
    }

    public class CardModel
    {
        [Display(Name = "Card Number")]
        [Required]
        public string CardNumber { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("[0-9]+$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorNumeric")]
        [StringLength(2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMaxLength")]
        public string Month { get; set; }

        [Required]
        [RegularExpression("[0-9]+$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorNumeric")]
        [StringLength(2, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMaxLength")]
        public string Year { get; set; }

        [Required]
        [RegularExpression("[0-9]+$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorNumeric")]
        [StringLength(4, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ErrorMaxLength")]
        public string CCV { get; set; }
    }
}