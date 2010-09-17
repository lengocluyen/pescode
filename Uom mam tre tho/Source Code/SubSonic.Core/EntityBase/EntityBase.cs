using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using StructureMap;
using SubSonic.Caching;
using SubSonic.Schema;
using SubSonic.Repository;
using SubSonic.Extensions;

namespace SubSonic.BaseClasses
{
    public abstract class EntityBase
    {
        public abstract object Id { get; set; }

        private Hashtable ForeignCache = new Hashtable();

        protected T GetForeign<T>(object key)
            where T : EntityBase, new()
        {
            string relation = typeof(T).Name;
            T foreign = ForeignCache[relation] as T;

            if (foreign == null || foreign.Id.Equals(key) == false)
            {
                foreign = this.FRepository<T>().Single<T>(key);
                ForeignCache[relation] = foreign;
            }
            return foreign;
        }

        protected void SetForeign<T>(T foreign)
            where T : EntityBase, new()
        {
            string relation = typeof(T).Name;
            ForeignCache[relation] = foreign;
        }

        protected void SetForeignList<T>(List<T> foreignList)
            where T : EntityBase, new()
        {
            string relation = "l-" + typeof(T).Name;
            ForeignCache[relation] = foreignList;
        }

        protected List<T> GetForeignList<T>(Expression<Func<T, bool>> expression) where T : EntityBase, new()
        {
            return GetForeignList<T>(false, null, expression);
        }

        protected List<T> GetForeignList<T>(
            string sortBy, Expression<Func<T, bool>> expression) where T : EntityBase, new()
        {
            return GetForeignList<T>(false, sortBy, expression);
        }

        protected List<T> GetForeignList<T>(
            bool refresh, Expression<Func<T, bool>> expression) where T : EntityBase, new()
        {
            return GetForeignList<T>(refresh, null, expression);
        }

        protected List<T> GetForeignList<T>(
            bool refresh, string sortBy, Expression<Func<T, bool>> expression) where T : EntityBase, new()
        {
            string key = "l-" + typeof(T).Name;
            List<T> foreign = ForeignCache[key] as List<T>;
            if (foreign == null || refresh)
            {
                if (string.IsNullOrEmpty(sortBy))
                {
                    foreign = this.FRepository<T>().All<T>().Where<T>(expression).ToList<T>();
                }
                else
                {
                    foreign = this.FRepository<T>().All<T>().Where<T>(expression).OrderBy(sortBy).ToList<T>();
                }
                ForeignCache[key] = foreign;
            }
            return foreign;
        }

        protected IGenericRepository<T> FRepository<T>()
            where T : EntityBase, new()
        {
            return ObjectFactory.GetInstance<IGenericRepository<T>>();
        }

    }

    public abstract class EntityBase<T> : EntityBase where T : EntityBase<T>, new()
    {
        protected static IGenericRepository<T> Repository
        {
            get { return ObjectFactory.GetInstance<IGenericRepository<T>>(); }
        }

        public static IQueryable<T> All()
        {
            return Repository.All<T>();
        }

        public static object Add(T entity)
        {
            object result = Repository.Add<T>(entity);
            if (result != null)
                CacheManager.Clear<T>();
            return result;

        }
        public static void AddMany(IEnumerable<T> items)
        {
            Repository.AddMany(items);
            CacheManager.Clear<T>();
        }

        public static int Update(T entity)
        {
            int rs = Repository.Update<T>(entity);
            if (rs > 0)
                CacheManager.Clear<T>();
            return rs;
        }
        public static int UpdateMany(IEnumerable<T> items)
        {
            int rs = Repository.UpdateMany(items);
            if (rs > 0)
                CacheManager.Clear<T>();
            return rs;
        }

        public static int LogicalDelete(object key)
        {
            int rs = 0;
            T entity = Repository.Single<T>(key);
            if (entity != null)
            {
                if (entity.SetPropertyDeleted(true))
                    rs = Repository.Update<T>(entity);
            }
            if (rs > 0)
                CacheManager.Clear<T>();
            return rs;
        }

        public static int LogicalDeleteMany(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> items = Repository.Find<T>(expression);
            foreach (var item in items)
                items.SetPropertyDeleted(true);
            return UpdateMany(items);
        }
        public static int Delete(object key)
        {
            int rs = Repository.Delete<T>(key);
            if (rs > 0)
                CacheManager.Clear<T>();
            return rs;
        }
        public static int DeleteMany(Expression<Func<T, bool>> expression)
        {
            int rs = Repository.DeleteMany<T>(expression);
            if (rs > 0)
                CacheManager.Clear<T>();
            return rs;
        }
        public static int DeleteMany(IEnumerable<T> items)
        {
            int rs = Repository.DeleteMany<T>(items);
            if (rs > 0)
                CacheManager.Clear<T>();
            return rs;
        }

        public static bool Exists(Expression<Func<T, bool>> expression)
        {
            return Repository.Exists<T>(expression);
        }
        public static T Single(object key)
        {
            return CacheManager.Single<T>(Repository, key);
        }
        public static T Single(Expression<Func<T, bool>> expression)
        {
            return Repository.Single<T>(expression);
        }

        public static List<T> Find(Expression<Func<T, bool>> expression)
        {
            return Repository.Find<T>(expression).ToList<T>();
        }

        public static PagedList<T> GetPaged(int pageIndex, int pageSize)
        {
            return Repository.GetPaged<T>(pageIndex, pageSize);
        }
        public static PagedList<T> GetPaged(int pageIndex, int pageSize, string sortBy)
        {
            return Repository.GetPaged<T>(sortBy, pageIndex, pageSize);
        }
        public static PagedList<T> GetPaged(int pageIndex, int pageSize, string sortBy, string wherePredicate, params object[] values)
        {
            if (string.IsNullOrEmpty(wherePredicate))
                return GetPaged(pageIndex, pageSize, sortBy);

            var query = All().Where(wherePredicate, values);
            int totalRecords = query.Count();
            query = query.OrderBy(sortBy);
            return new PagedList<T>(query, pageIndex, pageSize);
        }

        public static IQueryable<T> GetTop(int number)
        {
            return All().Take(number);
        }
        public static IQueryable<T> GetTop(int number, string sortBy)
        {
            return All().OrderBy(sortBy).Take(number);
        }
        public static IQueryable<T> GetTop(int number, string sortBy, string wherePredicate, params object[] values)
        {
            return All()
                .Where(wherePredicate, values)
                .OrderBy(sortBy)
                .Take(number);
        }

        public static List<T> GetCached()
        {
            return CacheManager.Get<T>();
        }


    }

}
