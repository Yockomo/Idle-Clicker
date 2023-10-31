using UnityEngine;

namespace Feature.CodeBase.GameLogic.Inputs
{
    public class InputSystem
    {
        public Vector3 HandleMovement()
        {
            Vector3 movement = Vector3.zero;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                movement.z = Input.GetKey(KeyCode.W) ? 1 : -1;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                movement.x = Input.GetKey(KeyCode.D) ? 1 : -1;
            return movement;
        }
    }
}