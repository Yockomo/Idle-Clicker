using System;
using System.Collections.Generic;
using Feature.CodeBase.GameLogic.Traders;
using UnityEngine;

namespace Feature.CodeBase.GameLogic.Res
{
    public class ResourceStorage
    {
        private Dictionary<Type, int> allResources;
        private Dictionary<string, TraderData> resourceTraders;

        public ResourceStorage(int initialSize)
        {
            InitAllResources(initialSize);
        }

        private void InitAllResources(int initialSize)
        {
            allResources = new Dictionary<Type, int>(initialSize);
            resourceTraders = new Dictionary<string, TraderData>(initialSize / 2);
        }
        
        public void RegisterResource(Type type,  int id)
        {
            allResources.Add(type, id);
        }

        public void RegisterResourceTrade(ResourceTradeTransition tradeTransition)
        {
            string key = CreateResourceTradersKey(tradeTransition.FromResId, tradeTransition.ToResId);
            if (resourceTraders.ContainsKey(key))
                return;
            TraderData data = new TraderData(tradeTransition.TransitionCost, tradeTransition.TransitionTime);
            resourceTraders.Add(key, data);
        }

        public int GetResourceId<T>() where T : BaseResource
        {
            if (!allResources.ContainsKey(typeof(T)))
                return -1;

            return allResources[typeof(T)];
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