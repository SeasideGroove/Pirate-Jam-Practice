using System.Collections.Generic;
using Character;
using TerminalEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MapSystems
{
    public class SpawnSystem : MapSubsystem
    {
        private readonly List<SpawnPoint> spawnPoints = new();
        private float spawnCooldown = 1f;
        private SurvivorEnemyController enemyPrefab;

        private float spawnTimer;
        private bool isPaused;

        public void AddPoint(SpawnPoint spawnPoint)
        {
            if (!spawnPoints.Contains(spawnPoint)) { spawnPoints.Add(spawnPoint); }
        }

        private void Start()
        {
            var spawnParams = FindFirstObjectByType<SpawnParameters>();
            if (spawnParams)
            {
                spawnCooldown = spawnParams.spawnCooldown;
                enemyPrefab = spawnParams.enemyPrefab;
            }

            var terminalEvents = MapSystem.FindOrRegister<TerminalEventSystem>();
            terminalEvents.OnGameOver += OnGameOver;
            terminalEvents.OnReset += OnReset;
        }

        private void FixedUpdate()
        {
            if (isPaused) { return; }
            if (spawnTimer <= 0f)
            {
                Spawn();
            }
            else
            {
                spawnTimer -= Time.fixedDeltaTime;
            }
        }

        private void Spawn()
        {
            if (!enemyPrefab || spawnPoints.Count == 0) { return; }
            
            int choice = Random.Range(0, spawnPoints.Count-1);
            Vector3 randomPoint = spawnPoints[choice].transform.position;

            Instantiate(enemyPrefab.gameObject, randomPoint, Quaternion.identity);
            spawnTimer = spawnCooldown;
        }

        private void OnGameOver()
        {
            isPaused = true;
        }

        private void OnReset()
        {
            isPaused = false;
            spawnTimer = spawnCooldown;
        }
    }
}