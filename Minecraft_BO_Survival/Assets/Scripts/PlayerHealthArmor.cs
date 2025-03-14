using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthArmor : MonoBehaviour
{
    //Player's armor and health bar
    public GameObject Player;
    public Image Blue;
    public Image Green;

    public float maxArmor = 100f;
    public float maxHealth = 100f;
    public float currentArmor;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentArmor = maxArmor;
        currentHealth = maxHealth;

        UpdateBars();
    }

    public void TakeDamage(float damage)
    {
        if(currentArmor > 0)
        {
            if(currentArmor >= damage)
            {
                currentArmor -= damage;
            }
            else 
            {
                float remainingDamage = damage - currentArmor;
                currentArmor = 0;
                currentHealth -= remainingDamage;
            }
        }
        else
        {
            currentHealth -= damage;
        }
        if (currentHealth <= 0f)
        {
            Die();
        }
        UpdateBars();
    }
    public void UpdateBars()
    {
        //Update the health green bar based on current health value
        Green.fillAmount = currentHealth / maxHealth;

        //Update the armor blue bar based on current armor value
        Blue.fillAmount = currentArmor / maxArmor;
    }
    public void Heal(float amount)
    {
        CW_MedKit medkit = Player.GetComponent<CW_MedKit>();
        if(medkit != null)
        {
            medkit.healAmount += (int)currentHealth;
        }
        CW_ArmorPlating armorplate = Player.GetComponent<CW_ArmorPlating>();
        if (armorplate != null)
        {
            armorplate.healArmorAmount += (int)currentArmor;
        }
        UpdateBars();
    }
    private void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}
