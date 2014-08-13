using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Lib;
using Core.Utilities;

namespace Core.CM
{
    class Contact : CoreObjectBase
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
        /// FirstName field of Contacts table
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// LastName field of Contacts table
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Email field of Contacts table
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phone field of Contacts table
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// City field of Contacts table
        /// </summary>
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
        /// Message field of Contacts table
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// IP field of Contacts table
        /// </summary>
        public string IP { get; set; }
        #endregion

        #region Methods
        public void TSP(byte iud, int? ID, int? ProductID = null, string Name = null, string Description = null)
        {
            TryExecute(db =>
            {
                db.tsp_ProductTestimonials(iud, ref ID, ProductID, Name, Description);
                this.ID = ID ?? 0;
            }, Logger: string.Format("TSP(iud = {0}, ID = {1}, ProductID = {2}, Name = {3}, Description = {4})", iud, ID, ProductID, Name, Description));
        }

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
        #endregion
    }
}
