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
            m_moveDirection = value.Get<Vector2>();
        }

        private void OnAttack(InputValue value)
        {
            weapon.Attack();
        }

        private WeaponController weapon;
    }
}