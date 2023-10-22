using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.Infrastructure.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.GameLogic.Traders
{
    public class Sawmill : MonoBehaviour
    {
        [SerializeField] private  int incomeResId;
        [SerializeField] private  int outcomeResId;
        
        private ResourceStorage storage;
        private Trader<BaseResource, BaseResource> trader;

        [Inject]
        private void Init(IResourceHandler resourceHandler, IInventory inventory)
        {
            string incomeResName = storage.GetResourceNameById(incomeResId);
            string outcomeResName = storage.GetResourceNameById(outcomeResId);
            TraderData data = storage.GetTraderData(incomeResName, outcomeResName);
            CoroutineRunner runner = new CoroutineRunner(this);
            trader = new Trader<BaseResource, BaseResource>(data, resourceHandler, inventory, runner);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                trader.Trade();
        }
    }
}