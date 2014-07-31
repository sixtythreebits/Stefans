using DB;

namespace Core.CM
{
    public class Favourite : GenericObjectBase<DBCoreDataContext>
    {
        #region Constructor

        public Favourite() : base(ConnectionFactory.GetCoreContext)
        {
        }

        #endregion

        #region Methods

        public void TSP(byte iud, int? ID, int? UserID, int? ProductID = null)
        {
            TryExecute(db =>
            {
                db.tsp_Favourites(iud, ref ID, UserID, ProductID);
            }, Logger: string.Format("TSP(iud = {0}, ID = {1}, UserID = {2}, ProductID = {3})", iud, ID, UserID, ProductID));
        }

        #endregion
    }
}
