using Character;
using UnityEngine;

namespace MapSystems
{
    public class SpawnParameters : MonoBehaviour
    {
        [Tooltip("The time in seconds between each spawn")]
        public float spawnCooldown = 1f;

        [Tooltip("The enemy archetype that will be spawned")]
        public SurvivorEnemyController enemyPrefab;
    }
}