using System;
using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.Infrastructure.SaveSystem;
using UnityEngine;
using Zenject;

public class test : MonoBehaviour
{
    private IResSaver saver;
    private IResourceHandler handler;
    
    [Inject]
    private void Init(IResSaver resSaver, IResourceHandler handler)
    {
        saver = resSaver;
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

    private void OnDestroy()
    {
        saver.SaveRes();
    }
}
