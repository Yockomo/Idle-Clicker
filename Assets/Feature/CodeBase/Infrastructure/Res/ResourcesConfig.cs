using Feature.CodeBase.GameLogic.Res;
using UnityEngine;

namespace Feature.CodeBase.Infrastructure.Res
{
    [CreateAssetMenu(fileName = "ResourcesConfig", menuName = "SO/ResConfig", order = 0)]
    public class ResourcesConfig : ScriptableObject
    {
        public BaseResource[] Resources;

        public ResourceTrade[] Transitions;
    }
}