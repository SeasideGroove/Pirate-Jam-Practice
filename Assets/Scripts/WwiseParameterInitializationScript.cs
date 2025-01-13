using UnityEngine;

public class WwiseParameterInitializationScript : MonoBehaviour
{
    [SerializeField] private AK.Wwise.RTPC m_musicVolume;

    private void Start()
    {
        Debug.Log($"Music volume: {m_musicVolume.GetGlobalValue()}");
        m_musicVolume.SetGlobalValue(100f);
    }
}
