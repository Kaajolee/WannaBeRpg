using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManaController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Slider healthSlider;

    private PlayerHealthController instance;
    //public TextMeshProUGUI manaText;
    //public Slider manaSlider;
    // Start is called before the first frame update
    void Start()
    {
        instance = PlayerHealthController.instance as PlayerHealthController;

        healthSlider.maxValue = instance.maxHealth;
        healthSlider.value = instance.health;
        healthText.text = instance.health.ToString();

        GlobalEvents.Instance.OnDamageTaken += ChangeHealthText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeHealthText()
    {
        healthSlider.maxValue = instance.maxHealth;
        healthSlider.value = instance.health;
        healthText.text = instance.health.ToString();
    }
}
