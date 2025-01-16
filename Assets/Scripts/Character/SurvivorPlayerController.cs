using MapSystems;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Character
{
    [RequireComponent(typeof(WeaponController))]
    public class SurvivorPlayerController : SurvivorCharacterController
    {
        protected override void Awake()
        {
            base.Awake();
            weapon = GetComponent<WeaponController>();
        }

        // Input Actions
        private void OnMove(InputValue value)
        {
            Vector2 moveInput = value.Get<Vector2>();
            m_moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);
        }

        private void OnAttack(InputValue value)
        {
            var screenMouse = Input.mousePosition;
            var worldMouse = Camera.main? Camera.main.ScreenToWorldPoint(screenMouse) : transform.position;
            var projection = MapSystem.CurrentIsometricProjection?
                MapSystem.CurrentIsometricProjection.worldToLocalMatrix : Matrix4x4.identity;
            
            Vector3 isometricMouse = projection * worldMouse;
            Vector3 isometricPlayer = projection * transform.position;
            var diff = isometricMouse - isometricPlayer;

            weapon.Attack(diff);
        }

        private WeaponController weapon;
    }
}