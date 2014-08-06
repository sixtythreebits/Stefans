using System.Xml.Linq;
using Lib;

namespace Core.CM
{
    public class Order : CoreObjectBase
    {
        #region Properties

        public int ID { get; set; }

        #endregion

        #region Methods

        public void TX(byte iud, string Xml)
        {
            TryExecute(db =>
            {
                var outParam = new XElement("temp");
                db.tx_Orders(iud, XElement.Parse(Xml), ref outParam);
                this.ID = outParam.IntValueOf("id") ?? 0;
            });
        }

        #endregion
    }
}
