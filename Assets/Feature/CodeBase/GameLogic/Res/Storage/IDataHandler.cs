using System;
using System.Collections.Generic;

namespace Feature.CodeBase.GameLogic.Res.Storage
{
    public interface IDataHandler
    {
        public Dictionary<Type, int> GetCurrentData();
        public void Clear();
    }
}