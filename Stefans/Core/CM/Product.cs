using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using Core.Utilities;
using Lib;

namespace Core.CM
{
    public class Product : CoreObjectBase
    {
        #region Properties

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Caption { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public string Image { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        [StringLength(1000)]
        public string Instruction { get; set; }

        public bool IsFeature { get; set; }

        public List<Dictionary> Ingredients { get; set; }

        public List<ProductTestimonial> Testimonials { get; set; }

        #endregion

        #region Methods

        public List<Product> GetList()
        {
            return TryToReturn(db => db.List_Products().Select(p => new Product
            {
                ID = p.ProductID,
                Caption = p.Caption,
                Price = p.Price,
                CRTime = p.CRTime
            }).ToList(), Logger: "GetList()");
        }

        public Product GetSingle(int ID, bool IncludeTestimonials = false)
        {
            return TryToReturn(db =>
            {
                var xml = db.GetSingle_Product(ID, IncludeTestimonials);

                if (xml != null)
                {
                    return new Product
                    {
                        ID = xml.IntValueOf("product_id").Value,
                        Caption = xml.ValueOf("caption"),
                        Description = xml.ValueOf("description"),
                        Image = xml.ValueOf("image"),
                        Price = xml.DecimalValueOf("price").Value,
                        Instruction = xml.ValueOf("instructions"),
                        IsFeature = xml.BooleanValueOf("is_feature") == true,
                        Ingredients = xml.Children("ingredients", "ingredient").Select(i => new Dictionary
                        {
                            ID = i.IntValueOf("ingredient_id").Value,
                            Caption = i.ValueOf("caption")
                        }).ToList(),
                        Testimonials = xml.Children("testimonials", "testimonial").Select(t => new ProductTestimonial
                        {
                            Name = t.ValueOf("name"),
                            Description = t.ValueOf("description")
                        }).ToList()
                    };
                }
                return null;
            }, Logger: string.Format("GetSingle(ID = {0}, IncludeTestimonials = {1})", ID, IncludeTestimonials));
        }

        public void TX(byte iud, string Xml)
        {
            TryExecute(db =>
            {
                var outParam = new XElement("temp");
                db.tx_Products(iud, XElement.Parse(Xml), ref outParam);
                var id = outParam.IntValueOf("id");
                if (id.HasValue)
                {
                    this.ID = id.Value;
                }
            }, Logger: string.Format("TX(iud = {0}, Xml = {1})", iud, Xml));
        }

        public void Delete(int? ID)
        {
            TryExecute((db => db.tsp_Products(2, ref ID, null, null, null, null, null)), Logger: string.Format("Delete(ID = {0})", ID));
        }

        public List<Product> GetTopFeatured()
        {
            return TryToReturn(db => 
                db.List_Products()
                  .OrderByDescending(p => p.IsFeature)
                  .ThenBy(p => Guid.NewGuid())
                  .Take(4)
                  .Select(p => new Product
                  {
                      ID = p.ProductID,
                      Caption = p.Caption,
                      Price = p.Price,
                      Description = p.Description,
                      Image = p.Image
                  }).ToList()
           , Logger: "GetTopFeatured()");
        }

        #endregion
    }
}
