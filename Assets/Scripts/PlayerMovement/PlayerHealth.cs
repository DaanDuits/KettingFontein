using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar, armorBar;
    public int healthRegen = 4, armorRegen;
    public float healthRegenTime = 3, armorRegenTime = 3f;
    float healthTimer, armorTimer;

    public void AddArmor(int amount)
    {
        if (armorBar.maxValue == 1)
        {
            armorBar.maxValue += amount - 1;
            armorRegen++;
            return;
        }

        armorBar.maxValue += amount;
        armorBar.value += amount;
        armorRegen++;
        armorRegenTime -= 0.2f;
        armorRegenTime = Mathf.Clamp(armorRegenTime, 0.5f, float.MaxValue);
    }

    public void AddHP(int amount)
    {
        healthBar.maxValue += amount;
    }
    public void AddRegen()
    {
        healthRegen++;
        healthRegenTime -= 0.2f;
        healthRegenTime = Mathf.Clamp(healthRegenTime, 0.5f, float.MaxValue);
    }

    public void TakeDamage(int damage)
    {
        if (armorBar.value == 0)
        {
            healthBar.value -= damage;
            return;
        }
        if (damage - (int)armorBar.value > 0)
        {
            healthBar.value -= damage - (int)armorBar.value;
            armorBar.value = 0;
        }
        else
            armorBar.value -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        healthTimer += Time.deltaTime;
        armorTimer += Time.deltaTime;
        if (healthTimer >= healthRegenTime)
        {
            healthBar.value += healthRegen;
            healthTimer = 0;
        }
        if (armorTimer >= armorRegenTime)
        {
            armorBar.value += armorRegen;
            armorTimer = 0;
        }
    }
}
