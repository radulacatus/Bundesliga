using Bundesliga.Api.Contracts;
using Bundesliga.DataAccess;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace Bundesliga.Api
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IBundesligaService, BundesligaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBundesligaContextService, BundesligaContextService>(new HierarchicalLifetimeManager());
            container.RegisterType<BundesligaContext, BundesligaContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<DataAccess.Team>, TeamRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<DataAccess.Game>, GameRepository>(new HierarchicalLifetimeManager());
        }
    }    
}