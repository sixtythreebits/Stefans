using System.ComponentModel.DataAnnotations;
using DB;
using Lib;

namespace Core.UM
{
    public class User : GenericObjectBase<DBCoreDataContext>
    {
        #region Constructor

        public User() : base(ConnectionFactory.GetCoreContext)
        {

        }

        #endregion

        #region Properties

        public int ID { set; get; }

        [Required]
        [EmailAddress]
        [StringLength(500)]
        public string Email { set; get; }

        [Required]
        [StringLength(200)]
        public string Password { set; get; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(100)]
        public string FirstName { set; get; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(100)]
        public string LastName { set; get; }

        public string Phone { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public int? StateID { set; get; }
        public string Zip { set; get; }
        public string City { set; get; }
        public bool IsActive { set; get; }

        #endregion

        #region Methods

        public void TSP(byte? iud = null, int? ID = null, string Password = null, string FirstName = null, string LastName = null, string Email = null, string Phone = null, string Address1 = null, string Address2 = null, int? StateID = null, string Zip = null, string City = null, bool? IsActive = null)
        {
            TryExecute(db =>
            {
                if (Password != null)
                {
                    Password = Password.MD5();
                }

                db.UM_tsp_Users(iud, ref ID, Password, FirstName, LastName, Email, Phone, Address1, Address2, StateID, Zip, City, IsActive);

                if (ID.HasValue)
                {
                    this.ID = ID.Value;
                }
            }, Logger: string.Format("TSP_Users(iud = {0}, ID = {1}, Password = {2}, FirstName = {3}, LastName = {4}, Email = {5}, Phone = {6}, Address1 = {7}, Address2 = {8}, StateID = {9}, Zip = {10}, City = {11}, IsActive = {12})", iud, ID, Password, FirstName, LastName, Email, Phone, Address1, Address2, StateID, Zip, City, IsActive));
        }

        public bool IsEmailUnique(string Email)
        {
            return TryToReturn(db => db.IsEmailUnique(Email, null) == true, Logger: string.Format("IsEmailUnique(Email = {0})", Email));
        }

        public User GetSingle(int? UserID, string Email = null)
        {
            return TryToReturn(db =>
            {
                var xml = db.UM_GetSingle_User(UserID, Email);
                if (xml != null)
                {
                    return new User
                    {
                        ID = xml.IntValueOf("user_id").Value,
                        Password = xml.ValueOf("password"),
                        FirstName = xml.ValueOf("first_name"),
                        LastName = xml.ValueOf("last_name"),
                        Address1 = xml.ValueOf("address1"),
                        Address2 = xml.ValueOf("address2"),
                        StateID = xml.IntValueOf("state_id"),
                        City = xml.ValueOf("city"),
                        Zip = xml.ValueOf("zip"),
                        Phone = xml.ValueOf("phone"),
                        IsActive = xml.BooleanValueOf("is_active") == true
                    };
                }
                return null;
            }, Logger: string.Format("GetSingle(UserID = {0}, Email = {1})", UserID, Email));
        }

        #endregion
    }
}
