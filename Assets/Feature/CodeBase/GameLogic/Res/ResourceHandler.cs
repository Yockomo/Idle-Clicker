using System;
using System.Collections.Generic;
using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.Infrastructure.Res;

namespace Feature.CodeBase.GameLogic.Res
{
    public class ResourceHandler : IInventory, IResourceHandler
    {
        
        //TODO
        public event Action<BaseResource, int> OnResoureceCountChangeEvent;

        private Dictionary<string, int> map;

        public ResourceHandler(BaseResource[] resources)
        {
            map = new Dictionary<string, int>(resources.Length);
            foreach (var res in resources)
                if(!map.ContainsKey(res.ResourceName))
                    map.Add(res.ResourceName, 0);
        }
        
        public int GetResourcesCount<T>()
        {
            
            //КАК??
            return -1;
        }

        public bool TryIncreaseResource<T>(int count) where T : BaseResource
        {
            return false;
        }

        public bool TryDecreaseResource<T>(int count) where T : BaseResource
        {
            return false;
        }
    }
}