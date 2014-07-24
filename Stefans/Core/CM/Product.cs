using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
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
