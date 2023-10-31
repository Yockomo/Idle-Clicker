using System;
using System.Collections;
using Feature.CodeBase.GameLogic.Inventory;
using Feature.CodeBase.GameLogic.Movement;
using UnityEngine;
using Zenject;

namespace Feature.CodeBase.GameLogic.Res.ResIncome
{
    public class Tree : MonoBehaviour
    {
        [SerializeField] private int count;
        [SerializeField] private float cooldown;
        
        private IResourceHandler resourceHandler;

        private bool cd;
        
        [Inject]
        private void Init(IResourceHandler resourceHandler)
        {
            this.resourceHandler = resourceHandler;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!cd && other.TryGetComponent(out Hero hero))
                StartCoroutine(GetResource());
        }

        private IEnumerator GetResource()
        {
            var time = Time.time + cooldown;
            cd = true;
            while (Time.time < time)
            {
                yield return new WaitForSeconds(Time.deltaTime);
            }

            cd = false;
            resourceHandler.TryIncreaseResource<Wood>(count);
        }
    }
}