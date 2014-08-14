using System.Collections.Generic;
using System.Linq;

namespace Core.CM
{
    public class CartItem : CoreObjectBase
    {
        #region Properties

        public int Quantity { get; set; }

        public Product Product { get; set; }

        #endregion

        #region Methods

        public void TSP(byte iud, int? ID, int UserID, int ProductID, int? Quantity = null)
        {
            TryExecute(db => db.tsp_CartItems(iud, ref ID, UserID, ProductID, Quantity), Logger: string.Format("TSP(iud = {0}, ID = {1}, UserID = {2}, ProductID = {3}, Quantity = {4})", iud, ID, UserID, ProductID, Quantity));
        }

        public List<CartItem> GetList(int UserID)
        {
            return TryToReturn(db => db.List_CartItems(UserID).Select(c => new CartItem
            {
                Quantity = c.Quantity,
                Product = new Product
                {
                    ID = c.ProductID,
                    Caption = c.Caption,
                    Price = c.Price,
                    Image = c.Image
                }
            }).ToList(), Logger: string.Format("GetList(UserID = {0})", UserID));
        }

        public bool IsCartFull(int UserID)
        {
            return TryToReturn(db => db.List_CartItems(UserID).Any(), Logger: string.Format("IsCartFull(UserID = {0})", UserID));
        }

        public decimal GetTotalAmount(int UserID)
        {
            return TryToReturn(() => GetList(UserID).Sum(c => c.Quantity * c.Product.Price), Logger: string.Format("GetTotalAmount(UserID = {0})", UserID));
        }

        #endregion
    }
}
