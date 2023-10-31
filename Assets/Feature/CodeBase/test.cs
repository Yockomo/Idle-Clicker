using System;
using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using UnityEngine;
using Zenject;

public class test : MonoBehaviour
{
    private IInventory inventory;
    private IResourceHandler handler;
    
    [Inject]
    private void Init(IInventory inventory, IResourceHandler handler)
    {
        this.inventory = inventory;
        this.handler = handler;
        handler.TryIncreaseResource<Wood>(10);
    }

    private void OnEnable()
    {
        handler.OnResoureceCountChangeEvent += Function;
    }

    private void OnDisable()
    {
        handler.OnResoureceCountChangeEvent -= Function;
    }

    private void Function(Type type, int count)
    {
        Debug.Log(type.FullName + " " + count);
    }
    
    private void Update()
    {
        // Debug.Log("Wood " + inventory.GetResourcesCount<Wood>());
        // Debug.Log("Timber " + inventory.GetResourcesCount<Timber>());
    }
}
