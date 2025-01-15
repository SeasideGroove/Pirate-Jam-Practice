using UnityEngine;

[CreateAssetMenu(fileName = "WwiseEventTriggerScript", menuName = "Scriptable Objects/Wwise Event Trigger")]
public class WwiseEventTriggerScript : ScriptableObject
{
    public AK.Wwise.Event Event;
    public GameObject TestSource;

    [ContextMenu("Test")]
    public void Test()
    {
        Trigger(TestSource);
    }

    public void Trigger(GameObject source)
    {
        Event.Post(source);
    }
}
