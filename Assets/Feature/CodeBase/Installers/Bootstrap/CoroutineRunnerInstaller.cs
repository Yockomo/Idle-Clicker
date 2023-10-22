using Feature.CodeBase.Infrastructure.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.Installers.Bootstrap
{
    public class CoroutineRunnerInstaller : MonoInstaller
    {
        [SerializeField] private MonoBehaviour coroutineRunner;
        
        public override void InstallBindings()
        {
            Container.Bind<CoroutineRunner>().FromNew().AsSingle().WithArguments(coroutineRunner).NonLazy();
        }
    }
}