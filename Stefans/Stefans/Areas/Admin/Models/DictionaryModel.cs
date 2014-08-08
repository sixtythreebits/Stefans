using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Stefans.Areas.Admin.Models
{
    public class DictionaryModel
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
    }
}


