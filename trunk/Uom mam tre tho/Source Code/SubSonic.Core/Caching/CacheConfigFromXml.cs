using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;

namespace SubSonic.Caching
{
    public class CacheConfigFromXml : ICacheConfigReader
    {
        public Dictionary<string, CacheConfig> Read()
        {
            Dictionary<String, CacheConfig> dic = new Dictionary<string, CacheConfig>();
            try
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CacheConfig.xml");
                if (!System.IO.File.Exists(path))
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\CacheConfig.xml");

                if (!System.IO.File.Exists(path))
                    return dic;

                XElement tables = XElement.Load(path);
                var list = tables.Descendants("Table");
                foreach (var item in list)
                {
                    var name = GetName(item);
                    if (name != "")
                    {
                        var cacheConfig = new CacheConfig();
                        cacheConfig.Name = name;
                        cacheConfig.CacheMode = GetCacheMode(item);

                        if (cacheConfig.CacheMode == CacheMode.OnFind)
                            cacheConfig.Size = GetSize(item);
                        else
                            cacheConfig.Size = 0;

                        cacheConfig.SortBy = GetExpression(item);
                        cacheConfig.Predicate = GetPredicate(item);

                        dic.Add(name, cacheConfig);
                    }
                }
            }
            catch
            {
                dic = new Dictionary<string, CacheConfig>();
            }

            return dic;
        }

        private CacheMode GetCacheMode(XElement item)
        {
            try
            {
                var cacheModeString = item.Attribute(XName.Get("CacheMode")).Value;
                return (CacheMode)Enum.Parse(typeof(CacheMode), cacheModeString);
            }
            catch
            {

                return CacheMode.None;
            }
        }

        private string GetName(XElement item)
        {
            try
            {
                return item.Attribute(XName.Get("EntityName")).Value;

            }
            catch
            {

                return "";
            }
        }

        private int GetSize(XElement item)
        {
            try
            {
                int size = int.Parse(item.Attribute(XName.Get("Size")).Value);
                if (size <= 0)
                    size = 1000;
                return size;

            }
            catch
            {

                return 1000;
            }
        }

        private string GetExpression(XElement item)
        {
            try
            {
                var sortby = item.Element(XName.Get("SortBy"));
                return sortby.Attribute(XName.Get("Expression")).Value;
            }
            catch
            {
                return "";
            }
        }

        private string GetPredicate(XElement item)
        {
            try
            {
                var where = item.Element(XName.Get("Where"));
                var pre = where.Attribute(XName.Get("Predicate")).Value;
                return pre == "" ? "1=1" : pre;
            }
            catch
            {
                return "1=1";
            }
        }
    }
}
