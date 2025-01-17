using UnityEngine;

namespace MapSystems
{
    public class SpawnPoint : MonoBehaviour
    {
        private void Start()
        {
            var spawnSystem = MapSystem.FindOrRegister<SpawnSystem>();
            if (spawnSystem) { spawnSystem.AddPoint(this); }
        }
    }
}