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
        public string IDString
        {
            get { return ID.ToString("00000000000"); }
        }

        public decimal TotalPrice { get; set; }
        public string StatusCaption { get; set; }
        public int ItemCount { get; set; }
        public string UserEmail { get; set; }
        public OrderAddress Shipping { get; set; }
        public OrderAddress Billing { get; set; }

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

        public List<Order> GetList()
        {
            return TryToReturn(db => db.List_Orders().Select(o => new Order
            {
                ID = o.OrderID,
                TotalPrice = o.TotalPrice,
                StatusCaption = o.Status,
                CRTime = o.CRTime,
                UserEmail = o.Email,
                Shipping = new OrderAddress
                {
                    FirstName = o.ShippingFirstName,
                    LastName = o.ShippingLastName,
                    Address1 = o.ShippingAddress1,
                    Address2 = o.ShippingAddress2,
                    State = o.ShippingState,
                    City = o.ShippingCity,
                    Zip = o.ShippingZip,
                    Phone = o.ShippingPhone
                },
                Billing = new OrderAddress
                {
                    FirstName = o.BillingFirstName,
                    LastName = o.BillingLastName,
                    Address1 = o.BillingAddress1,
                    Address2 = o.BillingAddress2,
                    State = o.BillingState,
                    City = o.BillingCity,
                    Zip = o.BillingZip,
                    Phone = o.BillingPhone
                }
            }).ToList(), Logger: "GetList()");
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
