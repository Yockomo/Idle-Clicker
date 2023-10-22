using UnityEngine;

namespace Feature.CodeBase.GameLogic.Resources
{
    [CreateAssetMenu(fileName = "ResourcesConfig", menuName = "SO/ResConfig", order = 0)]
    public class ResourcesConfig : ScriptableObject
    {
        public BaseResource[] Resources;
    }
}