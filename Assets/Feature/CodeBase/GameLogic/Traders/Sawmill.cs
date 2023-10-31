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
        
        private Trader<Wood, Timber> trader;

        [Inject]
        private void Init(ResourceStorage storage, IResourceHandler resourceHandler, IResourceChecker resourceChecker)
        {
            TraderData data = storage.GetTraderData(incomeResId, outcomeResId);
            CoroutineRunner runner = new CoroutineRunner(this);
            trader = new Trader<Wood, Timber>(data, resourceHandler, resourceChecker, runner);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
                trader.Trade();
        }
    }
}