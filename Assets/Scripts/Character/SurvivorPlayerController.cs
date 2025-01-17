using System;
using MapSystems;
using TerminalEvents;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    [RequireComponent(typeof(PlayerInput))]
    public class SurvivorPlayerController : SurvivorCharacterController
    {
        private PlayerInput input;

        protected override void Awake()
        {
            base.Awake();
            PlayerControllerSystem.RegisterPlayerController(this);
            input = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            var terminalEvents = MapSystem.FindOrRegister<TerminalEventSystem>();
            terminalEvents.OnGameOver += OnGameOver;
            terminalEvents.OnReset += OnReset;
        }

        public override void Kill()
        {
            var terminalEvents = MapSystem.FindOrRegister<TerminalEventSystem>();
            terminalEvents?.GameOver();
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

        private void OnGameOver()
        {
            input.DeactivateInput();
        }

        private void OnReset()
        {
            input.ActivateInput();
        }
    }
}