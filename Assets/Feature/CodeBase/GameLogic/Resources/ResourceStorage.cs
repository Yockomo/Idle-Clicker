using System.Collections.Generic;

namespace Feature.CodeBase.GameLogic.Resources
{
    public class ResourceStorage
    {
        public HashSet<BaseResource> AllResources { get; private set; }

        public ResourceStorage()
        {
            InitAllResources(2);
        }

        public ResourceStorage(int initialSize)
        {
            InitAllResources(initialSize);
        }

        private void InitAllResources(int initialSize)
        {
            AllResources = new HashSet<BaseResource>(initialSize);
        }
        
        public void Register(BaseResource resource)
        {
            if(!AllResources.Contains(resource))
                AllResources.Add(resource);
        }
    }
}