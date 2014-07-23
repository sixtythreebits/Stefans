using System;
using System.Collections.Generic;
using System.Linq;
using DB;

namespace Core
{
    [Serializable]
    public class Dictionary : GenericObjectBase<DBCoreDataContext>
    {
        #region Constructor

        public Dictionary() : base(ConnectionFactory.GetCoreContext)
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public string Caption { get; set; }
        public string Caption1 { get; set; }
        public int? CodeVal { get; set; }
        public int? ParentID { get; set; }
        public short? Level { get; set; }
        public string Hierarchy { get; set; }
        public string StringCode { get; set; }
        public short? DictionaryCode { get; set; }
        public bool? IsDefVal { get; set; }
        public bool? IsVisible { get; set; }
        public int? SortVal { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets list of dictionaries depending on input parameters
        /// </summary>
        /// <param name="Level">Dictionary level</param>
        /// <param name="DictionaryCode">Code of the dictionary</param>
        /// <param name="ShowInvisibleItems">Return or no invisibles?</param>
        /// <returns>List of dictionary objects</returns>
        public List<Dictionary> ListDictionaries(int? Level, int? DictionaryCode, bool? ShowInvisibleItems = null)
        {
            return TryToReturn(db => db.List_Dictionaries(Level, DictionaryCode, ShowInvisibleItems).Select(d => new Dictionary
            {
                ID = d.DictionaryID,
                SortVal = d.SortVal,
                Caption = d.Caption,
                Caption1 = d.Caption1,
                CodeVal = d.CodeVal,
                DictionaryCode = d.DictionaryCode,
                Hierarchy = d.Hierarchy,
                IsDefVal = d.DefVal,
                IsVisible = d.Visible,
                Level = d.Level,
                ParentID = d.ParentID,
                StringCode = d.StringCode
            }).ToList(), Logger: "ListDictionaries(Level = " + Level + ", DictionaryCode = " + DictionaryCode + ", ShowInvisibleItems= " + ShowInvisibleItems + ")");
        }
        #endregion
    }
}
