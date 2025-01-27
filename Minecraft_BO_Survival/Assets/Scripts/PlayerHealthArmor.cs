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

    void Update()
    {
        if(Input.GetKey(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        if(currentArmor > 0)
        {
            if(currentArmor - damage > 0)
            {
                currentArmor -= damage;
            }
            else
            {
                damage -= currentArmor;
                currentArmor = 0;
                currentHealth -= damage;
            }
        }
        else
        {
            currentHealth -= damage;
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
}
