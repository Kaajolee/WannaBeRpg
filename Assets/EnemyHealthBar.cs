using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider healthSlider;
    public EnemyHealthController parentHealthComponent;
    float health;
    float maxHealth;

    void Start()
    {
        if(transform.parent == null)
        {
            Debug.LogError("parent GO is null");
        }
        //parentHealthComponent = GetComponentInParent<EnemyHealthController>();
        if (parentHealthComponent == null)
        {
            Debug.LogError("Enemy health controller is null");
        }

        healthSlider = GetComponentInChildren<Slider>();

        health = parentHealthComponent.health;
        maxHealth = parentHealthComponent.maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        health = parentHealthComponent.health;

        if(healthSlider.value != health)
        {
            healthSlider.value = health;
        }
    }
}
