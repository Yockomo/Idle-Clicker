using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.GameLogic.Res.Storage;
using Feature.CodeBase.Infrastructure.Res;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Feature.CodeBase.Installers.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesConfig config;
        
        public override void InstallBindings()
        {
            config.Register();
            Container.Bind<ResourceStorage>().FromMethod(GetFilledStorage).AsSingle().NonLazy();
            ResourceHandler resourceHandler = new ResourceHandler(config.Resources);
            Container.Bind<IInventory>().FromInstance(resourceHandler as IInventory).AsSingle().NonLazy();
            Container.Bind<IResourceHandler>().FromInstance(resourceHandler).AsSingle().NonLazy();
            SceneManager.LoadScene("SampleScene");
        }
        
        private ResourceStorage GetFilledStorage()
        {
            int n = config.Resources.Count;
            ResourceStorage storage = new ResourceStorage(n);
            RegisterResources(storage);
            RegisterResourceTrades(storage);
            return storage;
        }

        private void RegisterResources(ResourceStorage storage)
        {
            foreach (var res in config.Resources)
                storage.RegisterResource(res.GetType(), res.Id);
        }

        private void RegisterResourceTrades(ResourceStorage storage)
        {
            foreach (var resourceTrade in config.Transitions)
                storage.RegisterResourceTrade(resourceTrade);
        }
    }
}