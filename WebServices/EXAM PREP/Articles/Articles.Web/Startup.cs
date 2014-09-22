using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.OwinHost;
using Articles.Data;

[assembly: OwinStartup(typeof(Articles.Web.Startup))]

namespace Articles.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // Added from nzhul
            //app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        //// Added from nzhul
        //private static StandardKernel CreateKernel()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Load(Assembly.GetExecutingAssembly());
        //    RegisterMappings(kernel);
        //    return kernel;
        //}

        //// Added from nzhul
        //private static void RegisterMappings(StandardKernel kernel)
        //{
        //    kernel.Bind<IArticlesData>().To<ArticlesData>().WithConstructorArgument("context", c => new ApplicationDbContext());
        //}
    }
}
