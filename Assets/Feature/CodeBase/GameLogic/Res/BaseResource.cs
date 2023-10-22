using System;

namespace Feature.CodeBase.GameLogic.Res
{
    [Serializable]
    public class BaseResource
    {
        public string ResourceName;

        public BaseResource()
        {
            
        }
        
        public BaseResource(string name)
        {
            ResourceName = name;
        }
    }
}