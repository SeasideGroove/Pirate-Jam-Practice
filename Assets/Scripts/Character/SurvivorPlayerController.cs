using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;

namespace Character
{
    [RequireComponent(typeof(WeaponController))]
    public class SurvivorPlayerController : SurvivorCharacterController
    {
        private void Awake()
        {
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
            weapon.Attack();
        }

        private WeaponController weapon;
    }
}