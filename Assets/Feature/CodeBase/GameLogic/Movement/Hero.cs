using Feature.CodeBase.GameLogic.Inputs;
using UnityEngine;

namespace Feature.CodeBase.GameLogic.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private InputSystem inputSystem;
        private HeroController heroController;

        private void Awake()
        {
            inputSystem = new InputSystem();
            Rigidbody rb = GetComponent<Rigidbody>();
            heroController = new HeroController(rb, speed);
        }

        private void FixedUpdate()
        {
            HandleHeroController();
        }

        private void HandleHeroController()
        {
            heroController.Move(inputSystem.HandleMovement());
        }
    }
}