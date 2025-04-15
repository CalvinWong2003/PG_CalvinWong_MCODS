using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthArmor : MonoBehaviour, IHealth
{
    //Player's armor and health bar
    public GameObject Player;
    Image Blue;
    Image Green;

    public float maxArmor = 100f;
    public float maxHealth = 100f;
    float currentArmor;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image i in images)
        {
            if (i.name == "Blue")
            {
                Blue = i;
            }
            if(i.name == "Green")
            {
                Green = i;
            }
        }
        currentArmor = maxArmor;
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
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
        currentArmor += amount;
        currentHealth += amount;
        UpdateBars();
    }
    private void Die()
    {
        Time.timeScale = 0f;
    }
}
