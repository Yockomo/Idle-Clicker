using System;
using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using TMPro;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.UI.Resources
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField] private int resourceId;
        [SerializeField] private TextMeshProUGUI text;
        
        private IResourceHandler resourceHandler;
        private Type resType;
        private BaseResource res;

        [Inject]
        private void Init(IResourceHandler resourceHandler, ResourceStorage resourceStorage, IResourceChecker checker)
        {
            this.resourceHandler = resourceHandler;
            Type type = resourceStorage.GetResourceType(resourceId);
            resType = type;
            var instance = Activator.CreateInstance(type);
            
            if (instance is BaseResource resource)
                res = resource;
            else
                Debug.LogError("Resource with such id dont exist");
            UpdateUI(checker.GetResourcesCount(resType));
        }

        private void OnEnable()
        {
            resourceHandler.OnResoureceCountChangeEvent += Check;
        }

        private void OnDisable()
        {
            resourceHandler.OnResoureceCountChangeEvent -= Check;
        }

        private void Check(Type type, int count)
        {
            if (resType == type)
            {
                UpdateUI(count);
            }
        }

        private void UpdateUI(int count)
        {
            text.text = $"{res.ResourceName} = {count}";
        }
    }
}