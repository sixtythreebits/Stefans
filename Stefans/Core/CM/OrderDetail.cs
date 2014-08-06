using System.Collections.Generic;
using System.Linq;

namespace Core.CM
{
    public class OrderDetail : CoreObjectBase
    {
        #region Properties

        public int ID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ProductCaption { get; set; }

        #endregion

        #region Methods

        public List<OrderDetail> GetList(int OrderID)
        {
            return TryToReturn(db => db.List_OrderDetails(OrderID).Select(d => new OrderDetail
            {
                ID = d.OrderDetailID,
                Quantity = d.Quantity,
                Price = d.Price,
                ProductCaption = d.ProductCaption
            }).ToList(), Logger: string.Format("GetList(OrderID = {0})", OrderID));
        }

        #endregion
    }
}
