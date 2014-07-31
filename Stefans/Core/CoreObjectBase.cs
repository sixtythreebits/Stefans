using DB;

namespace Core
{
    public class CoreObjectBase : GenericObjectBase<DBCoreDataContext>
    {
        #region Constructor

        public CoreObjectBase() : base(ConnectionFactory.GetCoreContext)
        {
        }

        #endregion
    }
}
