using UnityEngine;

namespace MapSystems
{
    public class MapSystemInitializer : MonoBehaviour
    {
        private void Awake()
        {
            MapSystem.RegisterMap(transform);
        }
    }
}