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
            Wood wood = new Wood();
            wood.Id = 0;
            wood.ResourceName = "Wood";
            Resources.Add(wood);

            Timber timber = new Timber();
            timber.Id = 1;
            timber.ResourceName = "Timber";
            Resources.Add(timber);
        }
    }
}