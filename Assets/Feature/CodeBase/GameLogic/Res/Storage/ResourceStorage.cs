using System;
using System.Collections.Generic;
using Feature.CodeBase.GameLogic.Traders;
using UnityEngine;

namespace Feature.CodeBase.GameLogic.Res
{
    public class ResourceStorage
    {
        private Dictionary<Type, int> allResourcesByType;
        private Dictionary<int, Type> allResourcesById;
        private Dictionary<string, TraderData> resourceTraders;

        public ResourceStorage(int initialSize)
        {
            InitAllResources(initialSize);
        }

        private void InitAllResources(int initialSize)
        {
            allResourcesByType = new Dictionary<Type, int>(initialSize);
            allResourcesById = new Dictionary<int, Type>(initialSize);
            resourceTraders = new Dictionary<string, TraderData>(initialSize / 2);
        }
        
        public void RegisterResource(Type type,  int id)
        {
            allResourcesByType.Add(type, id);
            allResourcesById.Add(id, type);
        }

        public void RegisterResourceTrade(ResourceTradeTransition tradeTransition)
        {
            string key = CreateResourceTradersKey(tradeTransition.FromResId, tradeTransition.ToResId);
            if (resourceTraders.ContainsKey(key))
                return;
            TraderData data = new TraderData(tradeTransition.TransitionCost, tradeTransition.TransitionTime);
            resourceTraders.Add(key, data);
        }

        public int GetResourceId(Type lol)
        {
            if(allResourcesByType.ContainsKey(lol)) 
                return allResourcesByType[lol];
            return -1;
        }

        public Type GetResourceType(int id)
        {
            if (allResourcesById.ContainsKey(id))
                return allResourcesById[id];
            return null;
        }
        
        public TraderData GetTraderData(int incomeResourceId, int outcomeResourceId)
        {
            string key = CreateResourceTradersKey(incomeResourceId, outcomeResourceId);
            if (resourceTraders.ContainsKey(key))
                return resourceTraders[key];
            Debug.LogError("There is no such key in dictionary");
            return new TraderData();
        }
        
        private string CreateResourceTradersKey(int fromId, int toId)
        {
            return new string(fromId + "-" + toId);
        }
    }
}