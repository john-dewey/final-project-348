using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachGoal : MonoBehaviour
{
    
    public GameObject memoryPiecePrefab; // Prefab of the memory piece to respawn
    public Transform memoryPieceSpawnPoint; // Spawn point of the memory piece

    private int enemiesKilled = 0; // Number of enemies killed
    public int killsForRespawn = 5; // Number of kills required for memory piece respawn

    void Start()
    {
        // Initial spawn of memory piece
        SpawnMemoryPiece();
    }

    // Call this method whenever an enemy is destroyed
    public void EnemyDestroyed()
    {
        enemiesKilled++;

        // Check if the required number of kills for respawn is reached
        if (enemiesKilled >= killsForRespawn)
        {
            Debug.Log("memory piece is spawn");
            // Respawn memory piece and reset kill count
            SpawnMemoryPiece();
            enemiesKilled = 0;
        }
    }

    void SpawnMemoryPiece()
    {
        // Spawn the memory piece at the spawn point
        Instantiate(memoryPiecePrefab, memoryPieceSpawnPoint.position, Quaternion.identity);
    }
}
