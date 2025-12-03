using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveManager> waveManagerList;
    [SerializeField] int waveManagerListIndex = 0;
    WaveManager waveManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waveManager = waveManagerList[waveManagerListIndex];
        StartCoroutine(SpawnObstacleInSingleWave());
    }

   

    // Using coroutine to spawn one wave of enemies
    IEnumerator SpawnObstacleInSingleWave()
    {
        List<Transform> pathPrefabs = waveManager.GetPathPrefab;
        int totalPaths = pathPrefabs.Count;
        int obstacleCount = 1;

        while (obstacleCount <= waveManager.GetNumberOfObstacleToSpawn)
        {
            // Spawn object from the first/starting path
            Vector3 spawnPosition = pathPrefabs[0].transform.position;
            GameObject newObstacle = Instantiate(waveManager.GetObstaclePrefab, spawnPosition, Quaternion.identity);
            newObstacle.transform.position = spawnPosition; // Force position before first render
            obstacleCount++;

            // Delay before spawning the next obstacle
            yield return new WaitForSeconds(waveManager.GetDelaySpawnTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}