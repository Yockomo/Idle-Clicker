using System;

namespace Feature.CodeBase.GameLogic.Traders
{
    [Serializable]
    public struct TraderData
    {        
        public int MinTradeCountForSingleTrade;
        public float TimeForSingleTrade;
        
        public TraderData(int count, float time)
        {
            MinTradeCountForSingleTrade = count;
            TimeForSingleTrade = time;
        }
    }
}