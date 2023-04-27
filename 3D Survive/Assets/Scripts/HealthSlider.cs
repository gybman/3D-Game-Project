using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Slider slider;
    public Text healthText;

    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = playerHealth.GetMaxHealth();
    }

    void Update()
    {
        slider.value = playerHealth.GetPlayerHealth();

        float healthPercent = (float)playerHealth.GetPlayerHealth() / (float)playerHealth.GetMaxHealth();

        healthText.text = $"Health: {playerHealth.GetPlayerHealth()}/{playerHealth.GetMaxHealth()}";
    }
}
