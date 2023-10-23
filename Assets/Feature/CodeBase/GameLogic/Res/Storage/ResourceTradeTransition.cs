using System;

namespace Feature.CodeBase.GameLogic.Res
{
    [Serializable]
    public struct ResourceTradeTransition
    {
        public int FromResId;
        public int ToResId;
        public int TransitionCost;
        public float TransitionTime;

        public ResourceTradeTransition(int fromResId, int toResId, int transitionCost, float transitionTime)
        {
            FromResId = fromResId;
            ToResId = toResId;
            TransitionCost = transitionCost;
            TransitionTime = transitionTime;
        }
    }
}