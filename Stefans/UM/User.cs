using System.ComponentModel.DataAnnotations;
using SystemBase;
using DB;

namespace UM
{
    public class User : ObjectBase
    {
        #region Properties

        public int ID { set; get; }

        [Required]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }

        [Required]
        public string FirstName { set; get; }

        [Required]
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

        public void TSP_Users(byte? iud = null, int? ID = null, string Password = null, string FirstName = null, string LastName = null, string Email = null, string Phone = null, string Address1 = null, string Address2 = null, int? StateID = null, string Zip = null, string City = null, bool? IsActive = null)
        {
            TryExecute(delegate()
            {
                using (var db = ConnectionFactory.GetUMContext())
                {
                    db.UM_tsp_Users(iud, ref ID, Password, FirstName, LastName, Email, Phone, Address1, Address2, StateID, Zip, City, IsActive);
                }
            }, Logger: string.Format("TSP_Users(iud = {0}, ID = {1}, Password = {2}, FirstName = {3}, LastName = {4}, Email = {5}, Phone = {6}, Address1 = {7}, Address2 = {8}, StateID = {9}, Zip = {10}, City = {11}, IsActive = {12})", iud, ID, Password, FirstName, LastName, Email, Phone, Address1, Address2, StateID, Zip, City, IsActive));
        }

        #endregion
    }
}