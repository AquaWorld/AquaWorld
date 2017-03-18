[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AquaWorld.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AquaWorld.Web.App_Start.NinjectWebCommon), "Stop")]

namespace AquaWorld.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Data;
    using Data.Contracts;
    using Data.Repositories;
    using Data.Models;
    using Data.Services.Contracts;
    using Data.Services;
    using IoC;
    using System.Web.Mvc;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            NinjectDependencyResolver ninjectResolver = new NinjectDependencyResolver(kernel);
            DependencyResolver.SetResolver(ninjectResolver); //MVC 

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAquaWorldDbContext)).To(typeof(AquaWorldDbContext)).InRequestScope();
            kernel.Bind(typeof(AquaWorldDbContext)).ToSelf().InRequestScope();
            kernel.Bind(typeof(IEfAquaWorldDataProvider<>)).To(typeof(EfAquaWorldDataProvider<>));

            kernel.Bind(s => s.From("AquaWorld.Data.Services")
                             .SelectAllClasses()
                             .BindDefaultInterface());

            kernel.Bind(s => s.From("AquaWorld.Data.Models")
                            .SelectAllClasses()
                            .BindDefaultInterface());
        }        
    }
}
