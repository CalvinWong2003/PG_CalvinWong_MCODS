using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthArmor : MonoBehaviour
{
    //Player's armor and health bar
    public GameObject Player;
    public Image Blue;
    public Image Green;
    public GameObject Enemy;

    public float maxArmor = 100f;
    public float maxHealth = 100f;
    public float currentArmor;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentArmor = maxArmor;
        currentHealth = maxHealth;

        UpdateHealthBar(currentHealth);
        UpdateArmorBar(currentArmor);
    }

    public void TakeDamage(float damage)
    {
        if(currentArmor > 0)
        {
            if(currentArmor >= damage)
            {
                currentArmor -= damage;
                UpdateArmorBar(currentArmor);
            }
            else 
            {
                float remainingDamage = damage - currentArmor;
                currentArmor = 0;
                UpdateArmorBar(currentArmor);
                currentHealth -= remainingDamage;
                UpdateHealthBar(currentHealth);
            }
        }
        else
        {
            currentHealth -= damage;
            UpdateHealthBar(currentHealth);
        }
        if (currentHealth <= 0f)
        {
            Die();
        }
    }
    public void UpdateHealthBar(float health)
    {
        CW_MedKit medkit = Player.GetComponent<CW_MedKit>();
        if(medkit != null)
        {
            medkit.healAmount += (int)currentHealth;
        }
        //Update the health green bar based on current health value
        Green.fillAmount = currentHealth / maxHealth;
    }
    public void UpdateArmorBar(float armor)
    {
        CW_ArmorPlating armorplate = Player.GetComponent<CW_ArmorPlating>();
        if (armorplate != null)
        {
            armorplate.healArmorAmount += (int)currentArmor;
        }
        //Update the armor blue bar based on current armor value
        Blue.fillAmount = currentArmor / maxArmor;
    }
    private void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}
