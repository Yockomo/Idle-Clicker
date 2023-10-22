using System;

namespace Feature.CodeBase.GameLogic.Resources
{
    [Serializable]
    public class BaseResource
    {
        public string ResourceName;

        public BaseResource(string name)
        {
            ResourceName = name;
        }
    }
}