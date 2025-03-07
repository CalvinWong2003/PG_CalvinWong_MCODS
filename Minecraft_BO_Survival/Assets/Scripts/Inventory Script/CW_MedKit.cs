using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_MedKit : MonoBehaviour, IUsable
{
    public GameObject Player;

    [Tooltip("The green UI Image representing the player's health bar")]
    public Image Green;

    public float numberOfUses = 2;

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
        for(int i = 0; i < numberOfUses; i++)
        {
            if(numberOfUses > 0)
            {
                Heal();
                Debug.Log("Number of Med Kits left: " + numberOfUses);
            }
            else
            {
                Debug.Log("No Med Kits available!!!");
            }
            numberOfUses--;
        }
    }

    private void Heal()
    {
        PlayerHealthArmor playerHealth = Player.GetComponent<PlayerHealthArmor>();
        if(playerHealth != null)
        {
            playerHealth.UpdateHealthBar(healAmount);
        }
    }
    public void use()
    {
        useMedKit();
    }
}
