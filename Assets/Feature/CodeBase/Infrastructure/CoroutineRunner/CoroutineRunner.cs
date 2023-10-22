using UnityEngine;

namespace Feature.CodeBase.Infrastructure.CoroutineRunner
{
    public class CoroutineRunner
    {
        public readonly MonoBehaviour Runner;

        public CoroutineRunner(MonoBehaviour runner)
        {
            Runner = runner;
        }
    }
}