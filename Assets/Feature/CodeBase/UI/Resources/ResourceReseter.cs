using Feature.CodeBase.Infrastructure.SaveSystem;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.UI.Resources
{
    public class ResourceReseter : MonoBehaviour
    {
        private IResReseter reseter;
        
        [Inject]
        private void Init(IResReseter reseter)
        {
            this.reseter = reseter;
        }
        
        public void ResetResources()
        {
            reseter.ResetResources();
        }
    }
}