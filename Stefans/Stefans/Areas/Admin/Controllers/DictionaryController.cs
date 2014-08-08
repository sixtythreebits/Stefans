using Core;
using DevExpress.Web.Mvc;
using Stefans.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stefans.Areas.Admin.Controllers
{
    public class DictionaryController : Controller
    {
        public DictionaryController()
        {
            ModelBinders.Binders.DefaultBinder = new DevExpressEditorsBinder();
        }
        //
        // GET: /Admin/Dictionary/
        public ActionResult Index()
        {
            Dictionary _Dictionary = new Dictionary();
            var model = _Dictionary.ListDictionaries(null, null, null);

            return View("_DyctionaryTreeList", model);
        }

        public ActionResult DictionaryCallback()
        {
            Dictionary _Dictionary = new Dictionary();
            var model = _Dictionary.ListDictionaries(null, null, null);

            return PartialView("_DyctionaryTreeList", model);
        }

        public ActionResult DictionaryAdd(DictionaryModel _Dictionary)
        {      
            if (ModelState.IsValid)
            {
                new Dictionary().TSP_Dictionaries(0, _Dictionary.ID, _Dictionary.Caption, _Dictionary.Caption1, _Dictionary.CodeVal, _Dictionary.ParentID, _Dictionary.Level, _Dictionary.Hierarchy, _Dictionary.StringCode, _Dictionary.DictionaryCode, _Dictionary.IsVisible, _Dictionary.SortVal);
            }
            else
            {
                ViewData["EditNodeError"] = "Please, correct all errors.";
            }

            var model = new Dictionary().ListDictionaries(null, null, null);
            return PartialView("_DyctionaryTreeList", model);
        }

        public ActionResult DictionaryUpdate(DictionaryModel _Dictionary)
        {
            if (ModelState.IsValid)
            {
                new Dictionary().TSP_Dictionaries(1, _Dictionary.ID, _Dictionary.Caption, _Dictionary.Caption1, _Dictionary.CodeVal, _Dictionary.ParentID, _Dictionary.Level, _Dictionary.Hierarchy, _Dictionary.StringCode, _Dictionary.DictionaryCode, _Dictionary.IsVisible, _Dictionary.SortVal);
            }
            else
            {
                ViewData["EditNodeError"] = "Please, correct all errors.";
            }


            var model = new Dictionary().ListDictionaries(null, null, null);
            return PartialView("_DyctionaryTreeList", model);
        }

        //public ActionResult DictionaryDragDrop(Dictionary _Dictionary)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _Dictionary.TSP_Dictionaries(1, _Dictionary.ID, _Dictionary.Caption, _Dictionary.Caption1, _Dictionary.CodeVal, _Dictionary.ParentID, _Dictionary.Level, _Dictionary.Hierarchy, _Dictionary.StringCode, _Dictionary.DictionaryCode, _Dictionary.IsVisible, _Dictionary.SortVal);
        //    }
        //    else
        //    {
        //        ViewData["EditNodeError"] = "Please, correct all errors.";
        //    }

        //    var model = _Dictionary.ListDictionaries(null, null, null);
        //    return PartialView("_DyctionaryTreeList", model);
        //}

        public ActionResult DictionaryDelete(Dictionary _Dictionary)
        {
            if (_Dictionary.ID > 0)
            {
                List<Dictionary> Childs = _Dictionary.ListDictionaries(null, null, null).Where(d => d.ParentID == _Dictionary.ID).ToList();

                if (Childs.Any())
                {
                    // Delete all child nodes
                    foreach( var item in Childs as List<Dictionary>)
                    {
                        _Dictionary.TSP_Dictionaries(2, item.ID, _Dictionary.Caption, _Dictionary.Caption1, _Dictionary.CodeVal, _Dictionary.ParentID, _Dictionary.Level, _Dictionary.Hierarchy, _Dictionary.StringCode, _Dictionary.DictionaryCode, _Dictionary.IsVisible, _Dictionary.SortVal);
                    }
                }

                _Dictionary.TSP_Dictionaries(2, _Dictionary.ID, _Dictionary.Caption, _Dictionary.Caption1, _Dictionary.CodeVal, _Dictionary.ParentID, _Dictionary.Level, _Dictionary.Hierarchy, _Dictionary.StringCode, _Dictionary.DictionaryCode, _Dictionary.IsVisible, _Dictionary.SortVal);
            }

            var model = _Dictionary.ListDictionaries(null, null, null);
            return PartialView("_DyctionaryTreeList", model);
        }

        
	}
}