using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
     public float health = 50f;
    public KillCount killsInRound;

    private void Start()
    {
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
        Destroy(gameObject);
        killsInRound.roundKills++;
    }

}
