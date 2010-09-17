using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using SubSonic.BaseClasses;
using System.Linq.Dynamic;
using SubSonic.Repository;
using System.Xml.Linq;
using SubSonic.Extensions;

namespace SubSonic.Caching
{
    public enum CacheMode
    {
        All,
        OnFind,
        None
    }
    public class CacheConfig
    {
        public CacheMode CacheMode { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string SortBy { get; set; }
        public string Predicate { get; set; }
    }

    public static class CacheManager
    {
        private static bool logInitialized = false;
        private static Dictionary<string, CacheConfig> configDic;

        public static void EnsureInitialized()
        {
            if (!logInitialized)
            {
                if (initialize())
                    logInitialized = true;
            }
        }

        private static bool initialize()
        {
            bool rs = false;
            try
            {
                ICacheConfigReader reader = ObjectFactory.GetInstance<ICacheConfigReader>();
                if (reader != null)
                {
                    configDic = reader.Read();
                    rs = true;
                }
            }
            catch (Exception)
            {
                configDic = new Dictionary<string, CacheConfig>();
                rs = false;
            }
            return rs;
        }

        public static void Refresh()
        {
            lock (configDic)
            {
                if (logInitialized)
                {
                    Flush();
                    initialize();
                }
            }
        }

        public static List<T> Get<T>() where T : EntityBase<T>, new()
        {
            CacheConfig config = GetConfig<T>();

            if (config == null)
                return new List<T>();

            string key = GenerateKey<T>();
            List<T> data = (List<T>)Cache.Get(key);

            if (data != null)
                return data;

            switch (config.CacheMode)
            {
                case CacheMode.All:
                    data = EntityBase<T>.All()
                        .Where(config.Predicate)
                        .OrderBy(config.SortBy).ToList();
                    data.TrimExcess();
                    Cache.Set(key, data);
                    break;
                case CacheMode.OnFind:
                    data = new List<T>(config.Size);
                    Cache.Set(key, data);
                    break;
                default:
                    break;
            }
            return data;
        }

        public static T Single<T>(IGenericRepository<T> rep, object key)
             where T : EntityBase<T>, new()
        {
            CacheConfig config = GetConfig<T>();
            if (config != null)
            {
                switch (config.CacheMode)
                {
                    case CacheMode.OnFind:
                        List<T> data = Get<T>();
                        T entity = null;
                        if (data != null)
                            entity = data.FirstOrDefault(x => x.Id.Equals(key));
                        if (entity == null)
                        {
                            entity = rep.Single<T>(key);
                            if (entity != null)
                            {
                                if (data.Count >= config.Size)
                                    Clear<T>();
                                data.Add(entity);
                            }
                        }
                        return entity;
                    case CacheMode.All:
                        List<T> all = Get<T>();
                        if (all != null)
                            return all.FirstOrDefault(x => x.Id.PrimaryKeyEquals(key));
                        return null;
                    default:
                        return rep.Single<T>(key);

                }
            }
            else
            {
                return rep.Single<T>(key);
            }
        }

        public static void Clear<T>() where T : EntityBase<T>, new()
        {
            if (logInitialized)
                Cache.Delete(GenerateKey<T>());
        }

        private static string GenerateKey<T>() where T : EntityBase<T>, new()
        {
            return String.Format("k-{0}", typeof(T).Name);
        }

        private static string[] GetCacheKeys()
        {
            if (configDic != null && configDic.Keys.Count > 0)
                return configDic.Keys.ToArray();
            return new string[0];
        }

        private static void Flush()
        {
            foreach (var key in GetCacheKeys())
                Cache.Delete(key);
        }

        private static CacheConfig GetConfig<T>() where T : EntityBase<T>, new()
        {
            if (!logInitialized)
                return null;

            string key = GenerateKey<T>();
            if (configDic.ContainsKey(key))
                return configDic[key];
            return null;
        }
    }
}
