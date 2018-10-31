using System;
using System.Data.Entity;

namespace Griedy.Lib.DataContext
{
    public partial class GriedyDataContext : IDataContext
    {
        private DbContextTransaction _transaction = null;

        public virtual void BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = Database.BeginTransaction();
            }
        }

        public virtual void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction = null;
            }
        }

        public virtual void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
        }

        private bool IsPrimitive(Type t)
        {
            if (t == null) { return false; }
            if (t.IsPrimitive) { return true; }
            if (t == typeof(string)) { return true; }
            if (t == typeof(DateTime)) { return true; }
            foreach (var x in t.GetGenericArguments())
            {
                if (IsPrimitive(x)) { return true; }
            }

            return false;
        }

        public virtual void UpdateValues<T>(T src, T dest) where T : class
        {
            if (src == null) { throw new ArgumentNullException(nameof(src)); }
            if (dest == null) { throw new ArgumentNullException(nameof(dest)); }

            var srcType = src.GetType();
            var destType = dest.GetType();
            foreach (var srcProp in srcType.GetProperties())
            {
                if (srcProp.CanRead && IsPrimitive(srcProp.PropertyType))
                {
                    var destProp = destType.GetProperty(srcProp.Name);
                    if (destProp != null && destProp.CanWrite && srcProp.PropertyType == destProp.PropertyType)
                    {
                        destProp.SetValue(dest, srcProp.GetValue(src));
                    }
                }
            }
        }
    }
}