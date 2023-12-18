using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject blueEnemyPrefab;
    public GameObject redEnemyPrefab;
    public float initialSpawnInterval = 10f;
    public float minSpawnInterval = 6f;
    public float spawnIntervalDecrement = 2f;
    public int maxEnemies = 30;

    private float currentSpawnInterval;
    private float timeSinceLastSpawn;
    private int numEnemies;
    private int enemiesPerSpawn = 1;
    private ObjectPool redEnemyPool;
    private ObjectPool blueEnemyPool;

    private int redEnemiesPerSpawn = 4;
    private int blueEnemiesPerSpawn = 1;

    public float radiusForSpawn;
    // Start is called before the first frame update
    void Start()
    {
           currentSpawnInterval = initialSpawnInterval;
        redEnemyPool = new ObjectPool();
        redEnemyPool.Initialize(redEnemyPrefab, maxEnemies);
        blueEnemyPool = new ObjectPool();
        blueEnemyPool.Initialize(blueEnemyPrefab, maxEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnInterval && numEnemies < maxEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                SpawnerEnemy();
            }
            timeSinceLastSpawn = 0f;
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecrement, minSpawnInterval);
            enemiesPerSpawn++;
        }
    }
    private void SpawnerEnemy()
    {

            for (int i = 0; i < redEnemiesPerSpawn; i++)
            {
                numEnemies++;
                GameObject redEnemy = redEnemyPool.GetObject();
                redEnemy.transform.position = GetRandomSpawnPosition();
                redEnemy.SetActive(true);
            }

            for (int i = 0; i < blueEnemiesPerSpawn; i++)
            {
                numEnemies++;
                GameObject blueEnemy = blueEnemyPool.GetObject();
                blueEnemy.transform.position = GetRandomSpawnPosition();
                blueEnemy.SetActive(true);
            }

    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.x += Random.Range(-radiusForSpawn, radiusForSpawn);
        spawnPosition.z += Random.Range(-radiusForSpawn, radiusForSpawn);
        return spawnPosition;
    }

    public void DecreaseNumEnemies()
    {
        numEnemies--;
    }
}
