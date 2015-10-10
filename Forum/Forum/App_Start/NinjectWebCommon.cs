[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Forum.App_Start.NinjectWebCommon), "Start")]
//[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Forum.App_Start.NinjectWebCommon), "RegisterMembership")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Forum.App_Start.NinjectWebCommon), "Stop")]

namespace Forum.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Repositories.Repositories;
    using Repositories.Repositories.Interfaces;
    using System;
    using System.Web;

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

        //public static void RegisterMembership()
        //{
        //    //bootstrapper.Kernel.Inject(Membership.Provider);
        //    //bootstrapper.Kernel.Inject(Roles.Provider);
        //} 

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
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
            kernel.Bind<IAvatarRepository>().To<AvatarRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IThreadRepository>().To<ThreadRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IV_CategoriesRepository>().To<V_CategoriesRepository>();
            kernel.Bind<IV_ThreadsRepository>().To<V_ThreadsRepository>();
            kernel.Bind<IWarningRepository>().To<WarningRepository>();
        }        
    }
}
