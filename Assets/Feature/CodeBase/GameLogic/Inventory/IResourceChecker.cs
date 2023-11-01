using System;
using Feature.CodeBase.GameLogic.Res;

namespace Feature.CodeBase.GameLogic.Inventory
{
    public interface IResourceChecker
    {
        public int GetResourcesCount<T>();
        public int GetResourcesCount(Type t);
    }
}