using UnityEngine;

public class BeatScript : MonoBehaviour
{
    public void Beat()
    {
        transform.localPosition = -transform.localPosition;
    }
}
