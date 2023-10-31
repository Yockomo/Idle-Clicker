using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Movement;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.Infrastructure.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.GameLogic.Traders
{
    public class Sawmill : MonoBehaviour
    {
        private Trader<Wood, Timber> trader;

        [Inject]
        private void Init(ResourceStorage storage, IResourceHandler resourceHandler, IResourceChecker resourceChecker)
        {
            Wood w = new Wood();
            Timber t = new Timber();
            TraderData data = storage.GetTraderData(w.Id, t.Id);
            CoroutineRunner runner = new CoroutineRunner(this);
            trader = new Trader<Wood, Timber>(data, resourceHandler, resourceChecker, runner);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!trader.Trading && other.TryGetComponent(out Hero hero))
                trader.Trade();
        }
    }
}