using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using Core.Utilities;
using DB;
using Lib;

namespace Core.CM
{
    public class Product : GenericObjectBase<DBCoreDataContext>
    {
        #region Constructor

        public Product() : base(ConnectionFactory.GetCoreContext)
        {
        }

        #endregion

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

        public List<Dictionary> Ingredients { get; set; }

        #endregion

        #region Methods
        public Product GetSingle(int ID)
        {
            return TryToReturn(db =>
            {
                var xml = db.GetSingle_Product(ID);

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
                        Ingredients = xml.Elements("ingredients", "ingredient").Select(i => new Dictionary
                        {
                            ID = i.IntValueOf("ingredient_id").Value,
                            Caption = i.ValueOf("caption")
                        }).ToList()
                    };
                }
                return null;
            });
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
            });
        }

        #endregion
    }
}
