using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.GameLogic.Res.Storage;
using Feature.CodeBase.Infrastructure.Res;
using Feature.CodeBase.Infrastructure.SaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Feature.CodeBase.Installers.Bootstrap
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesConfig config;
        [SerializeField] private PlayerData playerData;
        
        public override void InstallBindings()
        {
            config.Register();
            ResourceStorage storage = GetFilledStorage();
            Container.Bind<ResourceStorage>().FromInstance(storage).AsSingle().NonLazy();
            IDataHandler dataHandler = InitResourceHandler();         
            InitSaver(dataHandler, storage);
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

        private ResourceHandler InitResourceHandler()
        {
            ResourceHandler resourceHandler = new ResourceHandler(config.Resources);
            Container.Bind<IResourceChecker>().FromInstance(resourceHandler).AsSingle().NonLazy();
            Container.Bind<IResourceHandler>().FromInstance(resourceHandler).AsSingle().NonLazy();
            Container.Bind<IDataHandler>().FromInstance(resourceHandler).AsSingle().NonLazy();
            return resourceHandler;
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

        private void InitSaver(IDataHandler dataHandler, ResourceStorage storage)
        {
            ResSaver saver = new ResSaver(dataHandler, playerData, storage);
            saver.LoadRes();
            Container.Bind<IResSaver>().FromInstance(saver).AsSingle().NonLazy();
            Container.Bind<IResLoader>().FromInstance(saver).AsSingle().NonLazy();
        }
    }
}