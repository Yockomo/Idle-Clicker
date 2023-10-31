using System;
using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Res;
using Feature.CodeBase.Infrastructure.SaveSystem;
using UnityEngine;
using Zenject;

//TODO вынести сейв в отдельный класс, сделать класс для UI и смены сцен
public class test : MonoBehaviour
{
    private IResSaver saver;
    private IResourceHandler handler;
    
    [Inject]
    private void Init(IResSaver resSaver, IResourceHandler handler)
    {
        saver = resSaver;
        this.handler = handler;
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
