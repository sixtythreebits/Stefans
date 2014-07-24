using DB;

namespace Core.CM
{
    public class ProductTestimonial : GenericObjectBase<DBCoreDataContext>
    {
        #region Methods

        public ProductTestimonial() : base(ConnectionFactory.GetCoreContext)
        {
        }

        #endregion

        #region Properties

        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }

        #endregion
    }
}
