using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public KillCount killCount;
    public Target enemies;
    public int waveIncreaseStats = 3;   // will increase stats of enemies every certain number of waves
    public float enemyHealthIncrease = 10f;
    public int enemyStartingCount = 10;
    public int increaseEnemyCount = 3;
    private int currentRound = 1;
    public float enemyStartingHealth = 10f;
    public Text waveCounter;
    public Text killCountText;

    void Awake()
    {
        enemies.health = enemyStartingHealth;
        // Reset the static variable when the scene is loaded
        PickUpController.slotFull = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnManager.SpawnACertainNumberOfEnemies(enemyStartingCount));
        UpdateWaveCounter();
    }

    // Update is called once per frame
    void Update()
    {
        // Starts a new round and increases enemyCount
        if (killCount.roundKills == enemyStartingCount)
        {
            spawnManager.newRound = true;
            currentRound++;
            NewRoundStats();
            StartCoroutine(spawnManager.SpawnACertainNumberOfEnemies(enemyStartingCount));
            UpdateWaveCounter();
        }
    }

    void NewRoundStats()
    {
        killCount.roundKills = 0;
        enemyStartingCount += increaseEnemyCount;
        if (currentRound % waveIncreaseStats == 0)
        {
            enemies.health += enemyHealthIncrease;
        }
    }

    void UpdateWaveCounter()
    {
        waveCounter.text = "Wave " + currentRound.ToString();
    }

    public void UpdateKillCounter()
    {
        killCountText.text = "Kills: " + killCount.totalKills;
    }
}
