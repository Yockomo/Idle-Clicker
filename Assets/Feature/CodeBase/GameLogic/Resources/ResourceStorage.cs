using System.Collections.Generic;

namespace Feature.CodeBase.GameLogic.Resources
{
    public class ResourceStorage
    {
        private HashSet<BaseResource> allResources;

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
            allResources = new HashSet<BaseResource>(initialSize);
        }
        
        public void Register(BaseResource resource)
        {
            if(!allResources.Contains(resource))
                allResources.Add(resource);
        }
    }
}