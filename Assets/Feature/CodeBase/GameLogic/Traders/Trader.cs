using System.Collections;
using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.Infrastructure.CoroutineRunner;
using UnityEngine;

namespace Feature.CodeBase.GameLogic.Traders
{
    public class Trader<T, G>
        where T : BaseResource
        where  G : BaseResource
    {
        private bool stop;
        private TraderData data;
        private IResourceHandler resourceHandler;
        private IInventory inventory;
        private CoroutineRunner corRunner;

        public Trader(TraderData data, IResourceHandler resourceHandler, IInventory inventory, CoroutineRunner corRunner)
        {
            this.data = data;
            this.resourceHandler = resourceHandler;
            this.inventory = inventory;
            this.corRunner = corRunner;
        }
        
        public void Stop()
        {
            stop = true;
        }
        
        public void Trade()
        {
            TradeResources(data.MinTradeCountForSingleTrade);
        }

        public void Trade(int count)
        {
            count -= count % data.MinTradeCountForSingleTrade;
            TradeResources(count);
        }

        protected virtual void TradeResources(int count)
        {
            int tResCount = inventory.GetResourcesCount<T>();
            if(tResCount < count || !resourceHandler.TryDecreaseResource<T>(count))
                return;
            corRunner.Runner.StartCoroutine(TradeRes(count));
        }

        protected virtual IEnumerator TradeRes(int count)
        {
            int currentT = count;
            int currentG = 0;
            while (currentT > 0 && !stop)
            {
                yield return new WaitForSeconds(data.TimeForSingleTrade);
                currentT -= data.MinTradeCountForSingleTrade;
                currentG++;
            }

            if (currentT > 0)
                resourceHandler.TryIncreaseResource<T>(currentT);
            if (currentG > 0)
                resourceHandler.TryIncreaseResource<G>(currentG);
            stop = false;
        }
    }
}