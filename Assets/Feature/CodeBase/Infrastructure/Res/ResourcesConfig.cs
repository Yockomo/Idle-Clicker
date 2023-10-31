using System.Collections.Generic;
using Feature.CodeBase.GameLogic.Res;
using UnityEngine;

namespace Feature.CodeBase.Infrastructure.Res
{
    [CreateAssetMenu(fileName = "ResourcesConfig", menuName = "SO/ResConfig", order = 0)]
    public class ResourcesConfig : ScriptableObject
    {
        public List<BaseResource> Resources;

        public ResourceTradeTransition[] Transitions;

        public void Register()
        {
            Resources = new List<BaseResource>();
            Register<Wood>();
            Register<Timber>();
        }

        private void Register<T>() where T : new()
        {
            T res = new T();
            if (res is BaseResource resource)
                Resources.Add(resource);
        }
    }
}