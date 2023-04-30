using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnLocations;
    public bool newRound = false;
    public int newRoundCountDown = 5;
    private float spawnInterval = 1.5f;
    public int enemiesSpawned = 0;

    //public WaveCounter waveCounter;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke("SpawnEnemy", newRoundCountDown);

    }

    // Update is called once per frame
    void Update()
    {
        if (newRound)
        {
            //waveCounter.wave += 1;
            newRound = false;
            enemiesSpawned = 0;
        }
    }

    void SpawnEnemy()
    {
        int locationIndex = Random.Range(0, spawnLocations.Length);
        Instantiate(enemyPrefab, spawnLocations[locationIndex].position, Quaternion.identity);
    }

    public IEnumerator SpawnACertainNumberOfEnemies(int numOfEnemies)
    {
        while (enemiesSpawned < numOfEnemies)
        {
            spawnInterval = Random.Range(0.0f, 2.0f);
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
            enemiesSpawned++;
        }
    }
}
