using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class MyPlayerController : MyCharacterController
    {
        // Input Actions
        private void OnMove(InputValue value)
        {
            m_moveDirection = value.Get<Vector2>();
        }

        private void OnAttack(InputValue value)
        {
            Attack();
        }
    }
}