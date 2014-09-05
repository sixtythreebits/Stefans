using System;
using System.Data.Linq;
using System.Runtime.CompilerServices;
using SystemBase;
using Lib;

namespace Core
{
    public class GenericObjectBase<TContext> : ObjectBase where TContext : DataContext
    {
        private readonly Func<TContext> _contextCreator;

        public GenericObjectBase(Func<TContext> ContextCreator)
        {
            _contextCreator = ContextCreator;
        }

        protected void TryExecute(Action<TContext> M, MethodForCatch M1 = null, string Logger = null, [CallerFilePath] string CallerFilePath = "", [CallerLineNumber] int CallerLineNumber = 0)
        {
            TryExecute(() =>
            {
                using (var db = _contextCreator())
                {
                    M(db);
                }
            }, M1, Logger, CallerFilePath, CallerLineNumber);
        }

        protected T TryToReturn<T>(Func<TContext, T> M, MethodForCatch M1 = null, string Logger = null, [CallerFilePath] string CallerFilePath = "", [CallerLineNumber] int CallerLineNumber = 0)
        {
            return TryToReturn(() =>
            {
                using (var db = _contextCreator())
                {
                    return M(db);
                }
            }, M1, Logger, CallerFilePath, CallerLineNumber);
        }

        protected void ErrorProcessing(string Logger, Exception Ex, [CallerFilePath]string CallerFilePath = "", [CallerLineNumber]int CallerLineNumber = 0)
        {
            IsError = true;
            ErrorMessage = Ex.Message;
            string.Format("Source File - {0}\nLine Number - {1}\n{2} --- {3}", CallerFilePath, CallerLineNumber, Logger, ErrorMessage).LogString();
        }
    }
}
