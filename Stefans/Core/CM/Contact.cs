using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Lib;
using Core.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Core.CM
{
    public class Contact : CoreObjectBase
    {
        #region Properties
        /// <summary>
        /// ContactID field of Contacts table
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// UserID field of Contacts table
        /// </summary>
        public int? UserID { get; set; }
        /// <summary>
        /// StateID field of Contacts table
        /// </summary>
        public int? StateID { get; set; }    
        /// <summary>
        /// Caption of State in Dictionary
        /// </summary>
        public string StateCaption { get; set; }
        /// <summary>
        /// FirstName field of Contacts table
        /// </summary>
        [Required (ErrorMessage = "First Name is required.")]        
        [StringLength(100)]    
        public string FirstName { get; set; }
        /// <summary>
        /// LastName field of Contacts table
        /// </summary>
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(100)] 
        public string LastName { get; set; }
        /// <summary>
        /// Email field of Contacts table
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        /// <summary>
        /// Phone field of Contacts table
        /// </summary>        
        public string Phone { get; set; }
        /// <summary>
        /// City field of Contacts table
        /// </summary>
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string City { get; set; }
        /// <summary>
        /// LicensedHairCareProfessionalID field of Contacts table
        /// </summary>
        public int? LicensedHairCareProfessionalID { get; set; }
        /// <summary>
        /// TopicID field of Contacts table
        /// </summary>
        public int? TopicID { get; set; }
        /// <summary>
        /// Caption of Topic in Dictionary
        /// </summary>
        public string TopicCaption { get; set; }
        /// <summary>
        /// Message field of Contacts table
        /// </summary>
        [Required]
        public string Message { get; set; }
        /// <summary>
        /// IP field of Contacts table
        /// </summary>
        public string IP { get; set; }
        public string LicensedHairCareProfessional { get; set; }
        #endregion

        #region Methods
        
        /// <summary>
        /// CRUD operations on Contacts Table
        /// </summary>
        /// <param name="iud"></param>
        /// <param name="ID"></param>
        /// <param name="UserID"></param>
        /// <param name="StateID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Email"></param>
        /// <param name="Phone"></param>
        /// <param name="City"></param>
        /// <param name="LicensedHairCareProfessionalID"></param>
        /// <param name="TopicID"></param>
        /// <param name="Message"></param>
        /// <param name="IP"></param>
        public void TSP_Contacts(byte iud, int? ID, int? UserID, int? StateID, string FirstName, string LastName,
            string Email, string Phone, string City, int? LicensedHairCareProfessionalID, int? TopicID, string Message, string IP)
        {
            TryExecute(
                    db =>
                    {
                        db.tsp_Contacts(iud, ref ID, UserID, StateID, FirstName, LastName,
                            Email, Phone, City, LicensedHairCareProfessionalID, TopicID, Message, IP);
                        this.ID = ID ?? 0;
                    },
                    Logger: string.Format("TSP_Contacts: iud {0}, ID {1},  UserID {2}, StateID {3}, FirstName {4}, LastName {5}"
                    + "Email {6}, Phone {7}, City {8}, LicensedHairCareProfessionalID {9}, TopicID {10}, Message {11}, IP {12}",
                    iud, ID, UserID, StateID, FirstName, LastName, Email, Phone, City, LicensedHairCareProfessionalID, TopicID, Message, IP
                    )
                
                );
        }

        public List<Contact> ListContacts()
        {
            return TryToReturn(db => db.List_Contacts().Select(c => new Contact
            {
                ID = c.ContactID,
                UserID = c.UserID,
                StateID = c.StateID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                City = c.City,
                Message = c.Message,
                IP = c.IP,
                CRTime = c.CRTime,
                StateCaption = c.State,
                TopicCaption = c.Topic,
                LicensedHairCareProfessional = c.Licensed_Hair_Care_Professional
            }).OrderByDescending(t => t.CRTime).ToList(), Logger: string.Format("GetList(UserID = {0})", UserID));
        }
        #endregion
    }
}
