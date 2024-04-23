using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public GameObject pickupPrefab; // Reference to the pickup prefab
    public Transform[] spawnPoints; // Array of spawn points
    public float spawnInterval = 5f; // Time interval between each spawn

    private float timer = 0f; // Timer to track when to spawn the pickup
    private int currentSpawnPointIndex = 0; // Index of the current spawn point

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a pickup
        if (timer >= spawnInterval)
        {
            SpawnPickup(); // Spawn the pickup
            timer = 0f;   // Reset the timer
        }
    }

    void SpawnPickup()
    {
        // Get the current spawn point
        Transform spawnPoint = spawnPoints[currentSpawnPointIndex];

        // Instantiate the pickup prefab at the current spawn point
        Instantiate(pickupPrefab, spawnPoint.position, spawnPoint.rotation);

        // Move to the next spawn point
        currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPoints.Length;
    }
}
