using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.CM
{
    public class OrderDetail : CoreObjectBase
    {
        #region Properties

        public int ID { get; set; }
        public int? Quantity { get; set; }
        public int? ProductID { get; set; }
        public decimal? Price { get; set; }
        public string ProductCaption { get; set; }
        public string ImageName { get; set; }
        public DateTime? OrderTime { get; set; }
        public string OrderStatus { get; set; }
        public string Email { get; set; }
        public int? OrderID { get; set; }
        
        #endregion

        #region Methods

        public List<OrderDetail> GetList(int OrderID)
        {
            return TryToReturn(db => db.List_OrderDetails(OrderID).Select(d => new OrderDetail
            {
                ID = d.OrderDetailID,
                Quantity = d.Quantity,
                Price = d.Price,
                ProductCaption = d.ProductCaption,
                ProductID = d.ProductID,
                OrderTime = d.CRTime,
                OrderStatus = d.OrderStatus,
                Email = d.Email,
                OrderID = d.OrderID,
                

            }).ToList(), Logger: string.Format("GetList(OrderID = {0})", OrderID));
        }

        #endregion
    }
}
