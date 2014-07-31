using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lib;

namespace Core.CM
{
    public class ProductTestimonial : CoreObjectBase
    {
        #region Properties

        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }
        public string ProductCaption { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        #endregion

        #region Methods

        public void TSP(byte iud, int? ID, int? ProductID = null, string Name = null,  string Description = null)
        {
            TryExecute(db =>
            {
                db.tsp_ProductTestimonials(iud, ref ID, ProductID, Name, Description);
                this.ID = ID ?? 0;
            }, Logger: string.Format("TSP(iud = {0}, ID = {1}, ProductID = {2}, Name = {3}, Description = {4})", iud, ID, ProductID, Name, Description));
        }

        public ProductTestimonial GetSingle(int ID)
        {
            return TryToReturn(db =>
            {
                var xml = db.GetSingle_ProductTestimonial(ID);
                if (xml != null)
                {
                    return new ProductTestimonial
                    {
                        ID = xml.IntValueOf("record_id").Value,
                        ProductID = xml.IntValueOf("product_id").Value,
                        Name = xml.ValueOf("name"),
                        Description = xml.ValueOf("description")
                    };
                }
                return null;
            }, Logger: string.Format("GetSingle(ID = {0})", ID));
        }

        public List<ProductTestimonial> GetList()
        {
            return TryToReturn(db => db.List_ProductTestimonials().Select(t => new ProductTestimonial
            {
                ID = t.RecordID,
                ProductID = t.ProductID,
                ProductCaption = t.ProductCaption,
                Name = t.Name,
                Description = t.Description
            }).ToList(), Logger: "GetList()");
        }

        #endregion
    }
}
