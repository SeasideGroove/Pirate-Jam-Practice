using MapSystems;
using TerminalEvents;
using UnityEngine;

namespace Character
{
    public class SurvivorEnemyController : SurvivorCharacterController
    {
        [Header("Configure")]
        [Tooltip("Delay in seconds to wait before attacking player when in range")]
        public float AttackDelay = 0.1f;
        
        private enum EnemyState
        {
            Idle, Attacking, Moving, GameOver
        }
        private EnemyState currentState = EnemyState.Idle;
        private float attackTimer = -1f;
        private Vector2 attackDirection = Vector2.left;

        // Unity Events
        protected override void Awake()
        {
            base.Awake();
            weapon.OnWeaponReady += OnWeaponReady;
        }

        private void Start()
        {
            var terminalEvents = MapSystem.FindOrRegister<TerminalEventSystem>();
            terminalEvents.OnGameOver += OnGameOver;
            terminalEvents.OnReset += OnReset;
        }

        protected override void FixedUpdate()
        {
            if (currentState == EnemyState.Moving)
            {
                var target = PlayerControllerSystem.CurrentPlayerController
                    ? PlayerControllerSystem.CurrentPlayerController.transform
                    : transform;

                m_moveDirection = (target.position - transform.position).normalized;
                Move();
            }
            else if (currentState == EnemyState.Idle)
            {
                if (attackTimer >= AttackDelay)
                {
                    attackTimer = -1f;
                    currentState = EnemyState.Attacking;
                    Attack();
                }
                else if (attackTimer >= 0f)
                {
                    attackTimer += Time.fixedDeltaTime;
                }
                else
                {
                    currentState = EnemyState.Moving;
                }
            }
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Vector2 diff = other.transform.position - transform.position;
                attackDirection = diff.normalized;
                PrepareAttack();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                currentState = EnemyState.Moving;
            }
        }

        // Internal Interface
        public override void Kill()
        {
            var terminalEvents = MapSystem.Find<TerminalEventSystem>();
            if (terminalEvents)
            {
                terminalEvents.OnGameOver -= OnGameOver;
                terminalEvents.OnReset -= OnReset;
            }
            Destroy(gameObject);
        }

        private void Attack()
        {
            weapon.Attack(attackDirection);
        }

        private void PrepareAttack()
        {
            currentState = EnemyState.Idle;
            attackTimer = 0f;
        }

        private void OnWeaponReady()
        {
            if (currentState == EnemyState.Attacking)
            {
                Attack();
            }
        }

        private void OnGameOver()
        {
            Kill();
        }

        private void OnReset()
        {
            Kill();
        }
    }
}