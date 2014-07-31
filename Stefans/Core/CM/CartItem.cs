namespace Core.CM
{
    public class CartItem : CoreObjectBase
    {
        #region Methods

        public void TSP(byte iud, int? ID, int UserID, int ProductID, int Quantity)
        {
            TryExecute(db => db.tsp_CartItems(iud, ref ID, UserID, ProductID, Quantity), Logger: string.Format("TSP(iud = {0}, ID = {1}, UserID = {2}, ProductID = {3}, Quantity = {4})", iud, ID, UserID, ProductID, Quantity));
        }

        #endregion
    }
}
