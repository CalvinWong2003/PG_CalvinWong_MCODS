using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthArmor : MonoBehaviour
{
    //Armor bar Images
    public Image armorBorder;
    public Image Gray;
    public Image Blue;

    //Health bar Images
    public Image healthBorder;
    public Image Red;
    public Image Green;

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
            float armorDamage = Mathf.Min(damage, currentArmor);
            currentArmor -= armorDamage;
            damage -= armorDamage;
        }
        if(damage > 0f)
        {
            currentHealth -= damage;
            
            if(currentHealth <= 0f)
            {
                Die();
            }
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
        Debug.Log("Player has died! Game Over!!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            float enemyDamage = 10f;
            EnemyScript enemy = other.GetComponent<EnemyScript>();
            if(enemy != null)
            {
                enemyDamage = enemy.damage;
            }
            TakeDamage(enemyDamage);
        }
    }
}
