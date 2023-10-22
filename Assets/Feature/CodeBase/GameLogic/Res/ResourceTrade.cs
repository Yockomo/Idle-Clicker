using System;

namespace Feature.CodeBase.GameLogic.Res
{
    [Serializable]
    public struct ResourceTrade
    {
        public string FromRes;
        public string ToRes;
        public int TransitionCost;
        public float TransitionTime;

        public ResourceTrade(string fromRes, string toRes, int transitionCost, float transitionTime)
        {
            FromRes = fromRes;
            ToRes = toRes;
            TransitionCost = transitionCost;
            TransitionTime = transitionTime;
        }
    }
}