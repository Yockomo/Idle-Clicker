using Feature.CodeBase.GameLogic.Res;

namespace Feature.CodeBase.GameLogic.Inventory
{
    public interface IInventory
    {
        public int GetResourcesCount<T>() where T : BaseResource;
    }
}