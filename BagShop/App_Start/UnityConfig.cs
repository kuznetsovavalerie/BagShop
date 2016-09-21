using BagShop.BLL.Services;
using BagShop.Common.Interfaces;
using BagShop.Common.Interfaces.Services;
using BagShop.DAL;
using BagShop.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using System.Web.Mvc;
using Unity.Mvc5;

namespace BagShop
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("BagShop"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());
            container.RegisterType<UserManager<IdentityUser, Guid>>(new InjectionConstructor(container.Resolve<UserStore>()));
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IUserService, UserService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}