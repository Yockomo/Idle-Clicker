using Feature.CodeBase.GameLogic.Resources;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.Installers.Bootstrap
{
    public class ResourceStorageInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesConfig config;
        
        public override void InstallBindings()
        {
            Container.Bind<ResourceStorage>().FromMethod(GetFilledStorage);
        }

        private ResourceStorage GetFilledStorage()
        {
            int n = config.Resources.Length;
            ResourceStorage storage = new ResourceStorage(n);
            foreach (var res in config.Resources)
                storage.Register(res);
            return storage;
        }
    }
}