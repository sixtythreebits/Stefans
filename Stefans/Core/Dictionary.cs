using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Core
{
    [Serializable]
    public class Dictionary : CoreObjectBase
    {
        #region Properties

        public int ID { get; set; }
        [Required(ErrorMessage = "Caption  is required")]
        public string Caption { get; set; }        
        public string Caption1 { get; set; }
        public int? CodeVal { get; set; }
        public int? ParentID { get; set; }
        public short? Level { get; set; }
        public string Hierarchy { get; set; }
        public string StringCode { get; set; }
        [Required(ErrorMessage = "Dictionary Code  is required")]
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

        public void TSP_Dictionaries(byte iud, int? ID, string Caption, string Caption1, int? CodeVal, int? ParentID, short? Level, string Hierarchy, string StringCode, short? DictionaryCode, bool? IsVisible, int? SortVal)
        {
            TryExecute(db => db.tsp_Dictionaries(iud, ref ID, null, Caption, Caption1, CodeVal, ParentID, Level, Hierarchy, StringCode, DictionaryCode, null, IsVisible, SortVal, null)
                , Logger: string.Format("TSP_Dictionaries(iud = {0}, ID = {1}, Caption = {2}, Caption1 = {3}, CodeVal = {4}), ParentID = {5}, Level = {6}, Hierarchy = {7}, StringCode = {8}, DictionaryCode = {9}, IsVisible = {10}, SortVal = {11}"
                , iud, ID, Caption, Caption1, CodeVal, ParentID, Level, Hierarchy, StringCode, DictionaryCode, IsVisible, SortVal));
        }
        #endregion
    }
}
