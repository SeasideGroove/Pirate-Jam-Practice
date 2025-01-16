using UnityEngine;
using UnityEngine.Events;
using Weapons;

namespace Character
{
    [RequireComponent(typeof(WeaponController))]
    public class SurvivorCharacterController : MonoBehaviour
    {
        [Header("Configure")]
        public float MovementSpeed = 5; // JT: made public so that other scripts can change this in future
        protected WeaponController weapon;

        [Header("Events")]
        public UnityEvent<GameObject> StartedMoving;
        public UnityEvent<GameObject> StoppedMoving;

        [Header("Debug")]
        [SerializeField] protected Vector3 m_moveDirection; // JT: made protected so subclasses can change
        [SerializeField] protected bool m_isMoving;
        
        // Unity Events

        protected virtual void Awake()
        {
            m_isMoving = false;
            weapon = GetComponent<WeaponController>();
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Weapon"))
            {
                Kill();
            }
        }

        // Character Controller Interface
        public virtual void Kill()
        {
            Destroy(gameObject);
        }
            
        protected virtual void Move()
        {
            transform.localPosition += Time.fixedDeltaTime * MovementSpeed * m_moveDirection;

            TriggerMovementChangedEvents();
        }

        private void TriggerMovementChangedEvents()
        {
            if (m_moveDirection == Vector3.zero)
            {
                if (!m_isMoving)
                {
                    return;
                }

                m_isMoving = false;
                StoppedMoving.Invoke(gameObject);
            }
            else
            {
                if (m_isMoving)
                {
                    return;
                }

                m_isMoving = true;
                StartedMoving.Invoke(gameObject);
            }
        }
    }
}