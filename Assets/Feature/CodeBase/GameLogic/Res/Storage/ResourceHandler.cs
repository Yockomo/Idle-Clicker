using System;
using System.Collections.Generic;
using System.Linq;
using Feature.CodeBase.GameLogic.Inventory;

namespace Feature.CodeBase.GameLogic.Res.Storage
{
    public class ResourceHandler : IResourceChecker, IResourceHandler, IDataHandler
    {
        public event Action<Type, int> OnResoureceCountChangeEvent;

        private Dictionary<Type, int> map;

        public ResourceHandler (IList<BaseResource> resources)
        {
            map = new Dictionary<Type, int>(resources.Count);
            foreach (var res in resources)
            {
                Type type = res.GetType();                
                if(!map.ContainsKey(type))
                    map.Add(type, 0);
            }
        }
        
        public Dictionary<Type, int> GetCurrentData()
        {
            return map;
        }

        public void Clear()
        {
            var keys = map.Keys.ToList();
            map.Clear();
            foreach (var k in keys)
                map.Add(k, 0);
            
        }

        public int GetResourcesCount(Type t)
        {
            return GetCount(t);
        }

        public int GetResourcesCount<T>()
        {
            return GetCount(typeof(T));
        }

        private int GetCount(Type t)
        {
            if (map.ContainsKey(t))
                return map[t];
            return 0;
        }
        
        public bool TryIncreaseResource<T>(int count) where T : BaseResource
        {
            return TryChangeValue(typeof(T), count);
        }

        public bool TryDecreaseResource<T>(int count) where T : BaseResource
        {
            return TryChangeValue(typeof(T), count*-1);
        }

        private bool TryChangeValue(Type resType, int count)
        {
            if (!map.ContainsKey(resType))
                return false;
            map[resType] += count;
            map[resType] = Math.Max(0, map[resType]);
            OnResoureceCountChangeEvent?.Invoke(resType, map[resType]);
            return true;
        }
    }
}