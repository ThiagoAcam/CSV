using CSV.AplicationCore.Interfaces.Repositories;
using CSV.AplicationCore.Interfaces.Services;
using CSV.AplicationCore.Services;
using CSV.Infrastructure.Repository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CSV.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IClienteService, ClienteService>();
            container.RegisterType<ISeguroService, SeguroService>();
            container.RegisterType<IVeiculoService, VeiculoService>();

            container.RegisterType<IClienteRepository, ClienteRepository>();
            container.RegisterType<ISeguroRepository, SeguroRepository>();
            container.RegisterType<IVeiculoRepository, VeiculoRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}