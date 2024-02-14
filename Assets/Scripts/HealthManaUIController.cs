using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManaController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Slider healthSlider;
    //public TextMeshProUGUI manaText;
    //public Slider manaSlider;
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = HealthController.instance.maxHealth;
        healthSlider.value = HealthController.instance.health;
        healthText.text = HealthController.instance.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeHealthText();
    }
    void ChangeHealthText()
    {
        healthSlider.maxValue = HealthController.instance.maxHealth;
        healthSlider.value = HealthController.instance.health;
        healthText.text = HealthController.instance.health.ToString();
    }
}
