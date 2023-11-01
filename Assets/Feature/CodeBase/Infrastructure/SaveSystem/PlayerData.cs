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
        private ResData data;
        private Dictionary<Type, int> map;
        private ResourceStorage storage;
        private string path;

        private void OnEnable()
        {
            path = Application.persistentDataPath + "/data.json";
        }

        public void Clear()
        {
            for (int i = 0; i < data.Values.Count; i++)
            {
                data.Values[i] = 0;
            }
            foreach (var k in data.Keys)
            {
                Type type = storage.GetResourceType(k);
                map[type] = 0;
            }
        }
        
        public void Save(Dictionary<Type, int> data)
        {
            List<int> keys = new List<int>();
            foreach (var key in data.Keys)
            {
                int k = storage.GetResourceId(key);
                if(k != -1)
                    keys.Add(k);
            }
            SaveToJson(keys, data.Values.ToList());
        }

        private void SaveToJson(List<int> keys, List<int> values)
        {
            var resData = new ResData();
            resData.Keys = keys;
            resData.Values = values;
            var json = JsonUtility.ToJson(resData);
            System.IO.File.WriteAllText(path, json);
        }
        
        public Dictionary<Type, int> Load(ResourceStorage storage)
        {
            this.storage = storage;
            LoadFromJson();
            if(map == null)
                Init(storage);
            return map;
        }

        private void LoadFromJson()
        {
            try
            {
                string resData = System.IO.File.ReadAllText(path);
                data = JsonUtility.FromJson<ResData>(resData);
            }
            catch (Exception e)
            {
                data = new ResData();
            }
            if(data.Keys == null)
                data.Keys = new List<int>();
            if(data.Values == null)
                data.Values = new List<int>();
        }
        
        private void Init(ResourceStorage storage)
        {
            map = new Dictionary<Type, int>();
            
            for (int i = 0; i < data.Keys.Count; i++)
            {
                Type type = storage.GetResourceType(data.Keys[i]);
                if(!map.ContainsKey(type))
                    map.Add(type, 0);
                map[type] = data.Values[i];
            }
        }
    }

    [Serializable]
    public struct ResData
    {
        public List<int> Keys;
        public List<int> Values;
    }
}