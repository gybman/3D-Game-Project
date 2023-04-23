using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{

    private int playerHealth;
    [SerializeField] private float timeToHeal;
    [SerializeField] private int maxHealth;

    private ColorGrading colorGradingEffect;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        colorGradingEffect = GetComponentInChildren<PostProcessVolume>().profile.GetSetting<ColorGrading>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth == 0)
        {
            Debug.Log("Player Died");
        }
    }

    public void TakeDamage()
    {
        CancelInvoke("Heal");
        playerHealth--;
        InvokeRepeating("Heal", timeToHeal, timeToHeal);
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
