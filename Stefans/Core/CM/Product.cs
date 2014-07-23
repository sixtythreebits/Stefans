using DB;

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
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Instruction { get; set; }

        #endregion
    }
}
