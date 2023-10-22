using System;
using Feature.CodeBase.GameLogic.Res;

namespace Feature.CodeBase.GameLogic.Inventory
{
    public interface IResourceHandler
    {
        public bool TryIncreaseResource<T>(int count) where T : BaseResource; 
        public bool TryDecreaseResource<T>(int count) where T : BaseResource;
        public event Action<BaseResource, int> OnResoureceCountChangeEvent;
    }
}