using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject playerObstaclePrefab; // Assign this in the Inspector
    public GameObject opponentObstaclePrefab; // Assign this in the Inspector
    public float spawnInterval = 3f; // Time interval for spawning
    public float spawnAreaHeight = 4f; // Height of the spawn area
    public float spawnAreaWidth = 8f; // Width of the spawn area

    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(3f); // Wait 3 seconds before spawning

        while (true)
        {
            // Spawn player obstacle on the left side
            Vector2 playerSpawnPosition = new Vector2(-8f, Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2));
            Instantiate(playerObstaclePrefab, playerSpawnPosition, Quaternion.identity);

            // Spawn opponent obstacle on the right side
            Vector2 opponentSpawnPosition = new Vector2(8f, Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2));
            Instantiate(opponentObstaclePrefab, opponentSpawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval); // Wait before spawning the next pair of obstacles
        }
    }
}
