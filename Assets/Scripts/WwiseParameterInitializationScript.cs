using UnityEngine;

public class WwiseParameterInitializationScript : MonoBehaviour
{
    [SerializeField] private AK.Wwise.RTPC m_musicVolume;
    [Range(0f, 100f)]
    [SerializeField] private float m_startingValue;

    private void Start()
    {
        m_musicVolume.SetGlobalValue(m_startingValue);
    }
}
