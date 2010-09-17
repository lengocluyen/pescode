using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Configuration;
using StructureMap;
using SubSonic.Repository;
using Pes.Core.Impl;
using Pes.Core;
using System.Web.Mvc;
using System.Web.Routing;

namespace PESWeb
{
    public class Global : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
            routes.MapRoute(
                "Default",
                //Route name
                "{controller}/{action}/{id}",
                //URL with parameters.

                new { controller="HomeGames",action="Index",id=""}
                );
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            //Log.EnsureInitialized();
            //CacheManager.EnsureInitialized();

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Default"];

            ObjectFactory.Initialize(x =>
            {
                x.For(typeof(IGenericRepository<>))
                      .LifecycleIs(InstanceScope.PerRequest)
                      .Use(typeof(GenericRepository<>))
                      .WithCtorArg("connectionStringName").EqualTo(settings.Name)
                      .WithCtorArg("options").EqualTo(SimpleRepositoryOptions.None);

                x.For(typeof(IRedirector)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Redirector));

                x.For(typeof(IUserSession)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(UserSession));

                x.For(typeof(IEmail)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Email));

                x.For(typeof(IWebContext)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(WebContext));

                x.For(typeof(IConfiguration)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Pes.Core.Impl.Configuration));

                x.For(typeof(ICaptcha)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Captcha));

                x.For(typeof(INavigation)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(Navigation));

                x.For(typeof(IEmailService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(EmailService));

                x.For(typeof(ITagService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(TagService));

                x.For(typeof(IAccountService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(AccountService));

                x.For(typeof(IProfileService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(ProfileService));

                x.For(typeof(IProfileAttributeService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(ProfileAttributeService));

                x.For(typeof(IAlertService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(AlertService));

                x.For(typeof(IPrivacyService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(PrivacyService));

                x.For(typeof(IFriendService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(FriendService));

                x.For(typeof(IMessageService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(MessageService));

                x.For(typeof(IFileService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(FileService));
                x.For(typeof(IFolderService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(FolderService));

                x.For(typeof(IGroupService)).LifecycleIs(InstanceScope.PerRequest).Use(typeof(GroupService));


                //x.For(typeof(SubSonic.Caching.ICacheConfigReader))
                //  .LifecycleIs(InstanceScope.PerRequest)
                //  .Use(typeof(SubSonic.Caching.CacheConfigFromXml));

            });
             //ViewEngines.Engines.Clear();
             //ViewEngines.Engines.Add(new ChangeViewAddress());
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Log.Error(sender, "Error caught by the Global.asax: " + e.ToString());

            IRedirector redir = ObjectFactory.GetInstance<IRedirector>();
            redir.GoToHomePage();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
          
        }
    }
}