using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.DataProviders;

namespace SubSonic.Repository
{
    public interface IGenericRepository<T> : IRepository
        where T : class, new()
    {
        //#region IRepository Members

        //bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> expression);

        //IQueryable<T> All();

        //T Single(object key);

        //T Single(System.Linq.Expressions.Expression<Func<T, bool>> expression);

        //IList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression);

        //SubSonic.Schema.PagedList<T> GetPaged(int pageIndex, int pageSize);

        //SubSonic.Schema.PagedList<T> GetPaged(string sortBy, int pageIndex, int pageSize);

        //object Add(T item);

        //void AddMany(IEnumerable<T> items);

        //int Update(T item);

        //int UpdateMany(IEnumerable<T> items);

        //int Delete(T key);

        //int DeleteMany(System.Linq.Expressions.Expression<Func<T, bool>> expression);

        //int DeleteMany(IEnumerable<T> items);

        //#endregion
    }

    public class GenericRepository<Type> : SimpleRepository, IGenericRepository<Type>
      where Type : class, new()
    {
        public GenericRepository()
            : base() { }

        public GenericRepository(string connectionStringName)
            : base(connectionStringName) { }

        public GenericRepository(string connectionStringName, SimpleRepositoryOptions options)
            : base(connectionStringName, options) { }


        public GenericRepository(SimpleRepositoryOptions options)
            : base(options) { }

        public GenericRepository(IDataProvider provider)
            : base(provider) { }

        public GenericRepository(IDataProvider provider, SimpleRepositoryOptions options)
            : base(provider, options)
        {

        }

        //#region IGenericRepository<Type> Members

        //public bool Exists(System.Linq.Expressions.Expression<Func<Type, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<Type> All()
        //{
        //    throw new NotImplementedException();
        //}

        //public Type Single(object key)
        //{
        //    throw new NotImplementedException();
        //}

        //public Type Single(System.Linq.Expressions.Expression<Func<Type, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<Type> Find(System.Linq.Expressions.Expression<Func<Type, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        //public SubSonic.Schema.PagedList<Type> GetPaged(int pageIndex, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

        //public SubSonic.Schema.PagedList<Type> GetPaged(string sortBy, int pageIndex, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

        //public object Add(Type item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddMany(IEnumerable<Type> items)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Update(Type item)
        //{
        //    throw new NotImplementedException();
        //}

        //public int UpdateMany(IEnumerable<Type> items)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Delete(Type key)
        //{
        //    throw new NotImplementedException();
        //}

        //public int DeleteMany(System.Linq.Expressions.Expression<Func<Type, bool>> expression)
        //{
        //    throw new NotImplementedException();
        //}

        //public int DeleteMany(IEnumerable<Type> items)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion
    }

}
