using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_MedKit : MonoBehaviour, IUsable
{
    [Tooltip("The green UI Image representing the player's health bar")]
    public Image Green;

    [Tooltip("Current player health (should not exceed max health)")]
    public int currentHealth = 100;

    [Tooltip("Maximum health value")]
    public int maxHealth = 100;

    [Tooltip("Amount to heal when the medkit is used")]
    public int healAmount = 25;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            useMedKit();
        }
    }

    internal void useMedKit()
    {
        Debug.Log("Using MedKit to heal myself");

        if(currentHealth < maxHealth)
        {
            currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);

            if(Green != null)
            {
                Green.fillAmount = (float)currentHealth / maxHealth;
            }
            Debug.Log("Medkit used. Current health: " + currentHealth);
        }
        else
        {
            Debug.Log("Health is already full. Medkit not used.");
        }
    }
    

    public void use()
    {
        useMedKit();
    }
}
