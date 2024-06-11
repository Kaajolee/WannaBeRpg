using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider healthSlider;
    public EnemyHealthController parentHealthComponent;
    public TextMeshProUGUI healthText;
    float health;
    float maxHealth;

    void Start()
    {

        healthSlider = GetComponentInChildren<Slider>();

        health = parentHealthComponent.Health;
        maxHealth = parentHealthComponent.maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;

        UpdateHealthLabel();
    }

    // Update is called once per frame
    void Update()
    {
        health = parentHealthComponent.Health;
        if(healthSlider.value != health)
        {
            healthSlider.value = health;
            UpdateHealthLabel();

        }
        transform.LookAt(transform.position + Camera.main.transform.forward);
    }
    void UpdateHealthLabel()
    {
        float health = this.health;
        healthText.text = $"{(int)Mathf.Clamp(health, 0, maxHealth)}";
    } 
}
