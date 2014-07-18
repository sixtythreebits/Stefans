using System;
using System.Data.Linq;
using SystemBase;

namespace UM
{
    public class GenericObjectBase<T> : ObjectBase where T : DataContext, new()
    {
        private readonly Lazy<T> _dbInitializer;

        public T DB
        {
            get { return _dbInitializer.Value; }
        }

        public GenericObjectBase(Func<T> DbCreator)
        {
            _dbInitializer = new Lazy<T>(DbCreator);
        }
    }
}
