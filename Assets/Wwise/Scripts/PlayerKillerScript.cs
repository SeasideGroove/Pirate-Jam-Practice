using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerKillerScript : MonoBehaviour
{
    [SerializeField] private UnityEvent m_playerDeath;
    [SerializeField] private PlayerInput m_playerInput;
    [SerializeField] private GameObject m_playerImage;

    private void FixedUpdate()
    {
        Vector3 pos = transform.localPosition;
        if (Mathf.Max(Mathf.Abs(pos.x), Mathf.Abs(pos.y)) > 7.5f)
            KillPlayer();
    }

    private void KillPlayer()
    {
        m_playerInput.enabled = false;
        m_playerDeath.Invoke();
        m_playerImage.transform.localScale = new Vector3(1f, 0.5f, 1f);
    }
}
