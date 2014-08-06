using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Lib;

namespace Core.CM
{
    public class Order : CoreObjectBase
    {
        #region Properties

        public int ID { get; set; }
        public decimal TotalPrice { get; set; }
        public string StatusCaption { get; set; }
        public int ItemCount { get; set; }

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

        public List<Order> GetUserOrders(int UserID)
        {
            return TryToReturn(db => db.List_UserOrders(UserID)
                                       .OrderByDescending(o => o.CRTime)
                                       .Select(o => new Order
                                       {
                                           ID = o.OrderID,
                                           TotalPrice = o.TotalPrice,
                                           StatusCaption = o.Status,
                                           ItemCount = o.ItemCount ?? 0,
                                           CRTime = o.CRTime
                                       }).ToList(), Logger: string.Format("GetUserOrders(UserID = {0})", UserID));
        }

        #endregion
    }
}
