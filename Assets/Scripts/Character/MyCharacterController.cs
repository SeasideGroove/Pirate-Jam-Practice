using UnityEngine;

namespace Character
{
    public class MyCharacterController : MonoBehaviour
    {
        [Header("Configure")]
        public float MovementSpeed = 5; // JT: made public so that other scripts can change this in future

        [Header("Debug")]
        [SerializeField] protected Vector3 m_moveDirection; // JT: made protected so subclasses can change
        
        // Unity Events
        protected virtual void FixedUpdate()
        {
            Move();
        }

        // Character Controller Interface
        protected virtual void Move()
        {
            transform.localPosition += Time.fixedDeltaTime * MovementSpeed * m_moveDirection;
        }

        protected virtual void Attack()
        {
            Debug.Log("Attack!");
        }
    }
}