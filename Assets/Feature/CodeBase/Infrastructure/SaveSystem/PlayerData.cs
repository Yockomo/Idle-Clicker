using System;
using System.Collections.Generic;
using System.Linq;
using Feature.CodeBase.GameLogic.Res;
using UnityEngine;

namespace Feature.CodeBase.Infrastructure.SaveSystem
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SO/PlayerData", order = 1)]
    public class PlayerData : ScriptableObject
    {
        public List<int> Keys;
        public List<int> Values;

        private Dictionary<Type, int> map;
        private ResourceStorage storage;
        
        public void Save(Dictionary<Type, int> data)
        {
            List<int> keys = new List<int>();
            foreach (var key in data.Keys)
            {
                int k = storage.GetResourceId(key);
                if(k != -1)
                    keys.Add(k);
            }
            Keys = keys;
            Values = data.Values.ToList();
        }

        public Dictionary<Type, int> Load(ResourceStorage storage)
        {
            this.storage = storage;
            if(map == null)
                Init(storage);
            return map;
        }

        private void Init(ResourceStorage storage)
        {
            map = new Dictionary<Type, int>();
            if (Keys == null)
                Keys = new List<int>();
            if (Values == null)
                Values = new List<int>();
                
            for (int i = 0; i < Keys.Count; i++)
            {
                Type type = storage.GetResourceType(Keys[i]);
                if(!map.ContainsKey(type))
                    map.Add(type, 0);
                map[type] = Values[i];
            }
        }
    }
}