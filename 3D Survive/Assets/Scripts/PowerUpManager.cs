using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUps;
    public float chanceForPowerUp = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDied(Transform enemyDeathTransform)
    {
        float randomFloat = Random.Range(0f, 10f);
        Debug.Log(randomFloat);

        // If a power up is going to spawn, it chooses which powerup
        if (randomFloat <= chanceForPowerUp)
        {
            SpawnPowerUp(enemyDeathTransform);
        }
    }

    void SpawnPowerUp(Transform enemyDeathTransform)
    {
        int randomPowerUpIndex = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[randomPowerUpIndex], enemyDeathTransform.position, Quaternion.identity);
    }
}
