using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
     public float health = 50f;
    public KillCount killsInRound;
    public PowerUpManager powerUpManager;

    private void Start()
    {
        powerUpManager = GameObject.Find("PowerUpManager").GetComponent<PowerUpManager>();
        GameObject roundKills = GameObject.FindGameObjectWithTag("Player");
        killsInRound = roundKills.GetComponent<KillCount>();
    }
    public void TakeDamage(float amount) 
    {
        health -=amount;
        if(health <= 0f) 
        {
            Die();
        }
    }
    void Die () 
    {
        powerUpManager.EnemyDied(this.gameObject.transform);
        Destroy(gameObject);
        killsInRound.roundKills++;
        killsInRound.totalKills++;
        FindObjectOfType<RoundManager>().UpdateKillCounter();
    }
}
