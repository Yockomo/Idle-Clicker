using System.Collections.Generic;
using Feature.CodeBase.GameLogic.Traders;
using UnityEngine;

namespace Feature.CodeBase.GameLogic.Res
{
    public class ResourceStorage
    {
        private List<string> allResources;
        private Dictionary<string, TraderData> resourceTraders;

        public ResourceStorage(int initialSize)
        {
            InitAllResources(initialSize);
        }

        private void InitAllResources(int initialSize)
        {
            allResources = new List<string>(initialSize);
            resourceTraders = new Dictionary<string, TraderData>(initialSize / 2);
        }
        
        public void RegisterResource(BaseResource resource)
        {
            allResources.Add(resource.ResourceName);
        }

        public void RegisterResourceTrade(ResourceTrade trade)
        {
            string key = CreateResourceTradersKey(trade.FromRes, trade.ToRes);
            if (resourceTraders.ContainsKey(key))
                return;
            TraderData data = new TraderData(trade.TransitionCost, trade.TransitionTime);
            resourceTraders.Add(key, data);
        }
        
        public string GetResourceNameById(int id)
        {
            if (allResources.Count > id)
                return allResources[id];

            return null;
        }

        public int GetResourceIdByName(string name)
        {
            for (int i = 0; i < allResources.Count; i++)
                if (allResources[i] == name)
                    return i;

            return -1;
        }

        public TraderData GetTraderData(string incomeResourceName, string outcomeResourceName)
        {
            string key = CreateResourceTradersKey(incomeResourceName, outcomeResourceName);
            if (resourceTraders.ContainsKey(key))
                return resourceTraders[key];
            Debug.LogError("There is no such key in dictionary");
            return new TraderData();
        }
        
        private string CreateResourceTradersKey(string from, string to)
        {
            return new string(from + "-" + to);
        }
    }
}