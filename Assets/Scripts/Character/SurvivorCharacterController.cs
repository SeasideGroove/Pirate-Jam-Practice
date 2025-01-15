using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class SurvivorCharacterController : MonoBehaviour
    {
        [Header("Configure")]
        public float MovementSpeed = 5; // JT: made public so that other scripts can change this in future

        [Header("Events")]
        public UnityEvent<GameObject> StartedMoving;
        public UnityEvent<GameObject> StoppedMoving;

        [Header("Debug")]
        [SerializeField] protected Vector3 m_moveDirection; // JT: made protected so subclasses can change
        [SerializeField] protected bool m_moving;
        public Vector2 FacingDirection => m_moveDirection.normalized;

        private void Awake()
        {
            m_moving = false;
        }

        // Unity Events
        protected virtual void FixedUpdate()
        {
            Move();
        }

        // Character Controller Interface
        protected virtual void Move()
        {
            transform.localPosition += Time.fixedDeltaTime * MovementSpeed * m_moveDirection;

            TriggerMovementChangedEvents();
        }

        private void TriggerMovementChangedEvents()
        {
            if (m_moveDirection == Vector3.zero)
            {
                if (m_moving == false)
                {
                    return;
                }

                m_moving = false;
                StoppedMoving.Invoke(gameObject);
            }
            else
            {
                if (m_moving == true)
                {
                    return;
                }

                m_moving = true;
                StartedMoving.Invoke(gameObject);
            }
        }

        protected virtual void Attack()
        {
            Debug.Log("Attack!");
        }
    }
}