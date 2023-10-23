using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.GameLogic.Res.Storage;
using Feature.CodeBase.Infrastructure.Res;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.Installers.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesConfig config;
        
        public override void InstallBindings()
        {
            Container.Bind<ResourceStorage>().FromMethod(GetFilledStorage).AsSingle().NonLazy();
            ResourceHandler resourceHandler = new ResourceHandler(config.Resources);
            Container.Bind<IInventory>().FromInstance(resourceHandler).AsSingle().NonLazy();
            Container.Bind<IResourceHandler>().FromInstance(resourceHandler).AsSingle().NonLazy();
        }
        
        private ResourceStorage GetFilledStorage()
        {
            int n = config.Resources.Length;
            ResourceStorage storage = new ResourceStorage(n);
            RegisterResources(storage);
            RegisterResourceTrades(storage);
            return storage;
        }

        private void RegisterResources(ResourceStorage storage)
        {
            foreach (var res in config.Resources)
                storage.RegisterResource(res);
        }

        private void RegisterResourceTrades(ResourceStorage storage)
        {
            foreach (var resourceTrade in config.Transitions)
                storage.RegisterResourceTrade(resourceTrade);
        }
    }
}