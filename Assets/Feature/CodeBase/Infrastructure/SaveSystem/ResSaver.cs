﻿using System;
using System.Collections.Generic;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.GameLogic.Res.Storage;

namespace Feature.CodeBase.Infrastructure.SaveSystem
{
    public class ResSaver : IResSaver, IResLoader
    {
        private Dictionary<Type, int> map;
        private PlayerData playerData;
        private ResourceStorage storage;
        
        public ResSaver(IDataHandler dataHandler, PlayerData playerData, ResourceStorage storage)
        {
            map = dataHandler.GetCurrentData();
            this.playerData = playerData;
            this.storage = storage;
        }
        
        public void SaveRes()
        {
            playerData.Save(map);
        }

        public void LoadRes()
        {
            Dictionary<Type, int> loaded = playerData.Load(storage);
            foreach (var pair in loaded)
            {
                if(!map.ContainsKey(pair.Key))
                    map.Add(pair.Key, 0);
                map[pair.Key] = pair.Value;
            }
        }
    }
}