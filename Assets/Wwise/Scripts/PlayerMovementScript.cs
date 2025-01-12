using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("Configure")]
    [SerializeField] private float m_movementSpeed;

    [Header("Debug")]
    [SerializeField] private Vector3 m_moveDirection;

    private void OnMove(InputValue value)
    {
        m_moveDirection = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        transform.localPosition += Time.fixedDeltaTime * m_movementSpeed * m_moveDirection;
    }
}
