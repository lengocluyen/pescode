using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using System.Configuration;
using StructureMap;
using SubSonic.Repository;
using SubSonic.Caching;

namespace SubSonic.StructureMap
{
    public class ComponentRegistry : Registry
    {
        public ComponentRegistry()
            : this("Default")
        {

        }
        public ComponentRegistry(string connectionStringName)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionStringName];

            For(typeof(IGenericRepository<>))
                .LifecycleIs(InstanceScope.PerRequest)
                .Use(typeof(GenericRepository<>))
                .WithCtorArg("connectionStringName").EqualTo(settings.Name)
                .WithCtorArg("options").EqualTo(SimpleRepositoryOptions.None);

            For(typeof(ICacheConfigReader))
             .LifecycleIs(InstanceScope.PerRequest)
             .Use(typeof(CacheConfigFromXml));

            For(typeof(ICache))
             .LifecycleIs(InstanceScope.PerRequest)
             .Use(typeof(SubSonic.Caching.Cache));
        }
    }
}
