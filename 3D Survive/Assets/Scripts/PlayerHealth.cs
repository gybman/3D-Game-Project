using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{

    private int playerHealth;
    [SerializeField] private float timeToHeal;
    [SerializeField] private int maxHealth;
    public AudioClip[] damagedSFX;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerDied()
    {
        GetComponent<AudioSource>().clip = damagedSFX[damagedSFX.Length - 1];
        GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
    }

    public void TakeDamage()
    {
        CancelInvoke("Heal");
        playerHealth--;
        if(playerHealth == 0)
        {
            PlayerDied();
        }
        else
        {
            GetComponent<AudioSource>().clip = damagedSFX[Random.Range(0, damagedSFX.Length - 1)];
            GetComponent<AudioSource>().Play();
            InvokeRepeating("Heal", timeToHeal, timeToHeal);
        }
    }

    private void Heal()
    {
        if (playerHealth < maxHealth)
        {
            playerHealth++;
        }
        Debug.Log("Health: " + playerHealth);
    }
}
