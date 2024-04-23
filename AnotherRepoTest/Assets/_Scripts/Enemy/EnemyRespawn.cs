using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
        public GameObject[] enemyPrefabs; // Array of enemy prefabs
        public Transform spawnPoint; // Reference to the spawn point

        private GameObject currentEnemy; // Reference to the current enemy

        void Start()
        {
            SpawnEnemy();
        }

        void SpawnEnemy()
        {
            // Choose a random enemy prefab from the array
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Spawn the enemy at the spawn point
            currentEnemy = Instantiate(randomEnemyPrefab, spawnPoint.position, Quaternion.identity);
        }

        public void EnemyDestroyedByPlayer()
        {
            // Respawn the enemy only if it's destroyed by the player
            if (currentEnemy != null)
            {
                // Respawn the enemy at the spawn point
                currentEnemy.transform.position = spawnPoint.position;
            }
            else
            {
                // If current enemy is null (e.g., destroyed by something else), spawn a new one
                SpawnEnemy();
            }
        }
    }
