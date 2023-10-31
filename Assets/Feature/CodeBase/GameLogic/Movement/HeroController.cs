using UnityEngine;

namespace Feature.CodeBase.GameLogic.Movement
{
    public class HeroController
    {
        private Rigidbody rb;
        private float moveSpeed;
        
        public HeroController( Rigidbody rb, float moveSpeed)
        {
            this.rb = rb;
            this.moveSpeed = moveSpeed;
        }

        public void Move(Vector3 direction)
        {
            Vector3 moveValue = direction * moveSpeed;
            moveValue.y = rb.velocity.y;
            rb.velocity = moveValue;
        }
    }
}