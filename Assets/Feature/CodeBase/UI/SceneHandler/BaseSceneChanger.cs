using Feature.CodeBase.Infrastructure.SceneHandler;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.UI.SceneHandler
{
    public abstract class BaseSceneChanger : MonoBehaviour
    {
        protected ISceneHandler sceneHandler;
        
        [Inject]
        protected virtual void Init(ISceneHandler handler)
        {
            sceneHandler = handler;
        }

        public abstract void LoadNextScene();
    }
}