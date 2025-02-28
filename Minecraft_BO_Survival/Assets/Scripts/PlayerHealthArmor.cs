using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthArmor : MonoBehaviour
{
    //Player's armor and health bar
    public Image Blue;
    public Image Green;
    public GameObject Enemy;
    public GameObject gameOverUI;

    public float maxArmor = 100f;
    public float maxHealth = 100f;
    private float currentArmor;
    private float currentHealth;

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
                return;
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
    void UpdateBars()
    {
        //Update the armor blue bar based on current armor value
        Blue.fillAmount = currentArmor / maxArmor;

        //Update the health green bar based on current health value
        Green.fillAmount = currentHealth / maxHealth;
    }
    private void Die()
    {
        Destroy(gameObject);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
