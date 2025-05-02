using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_MedKit : MonoBehaviour, IUsable
{
    public GameObject Player;
    Image Green;
    float numberOfUses;
    float numberOfUseLimit = 2;
    internal int healAmount = 25;

    public void AddUse()
    {
        numberOfUses++;
    }

    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image i in images)
        {
            if(i.name == "Green")
            {
                Green = i;
            }
        }
        numberOfUses = numberOfUseLimit;
    }

    internal void useMedKit()
    {
        for(int i = 0; i < numberOfUses; i++)
        {
            if(numberOfUses > 0)
            {
                PlayerHealthArmor playerHealth = Player.GetComponent<PlayerHealthArmor>();
                if(playerHealth != null)
                {
                    playerHealth.Heal(healAmount);
                    numberOfUses--;
                }
                Debug.Log("Number of Med Kits left: " + numberOfUses);
            }
            else
            {
                Debug.Log("No Med Kits available!!!");
            }
        }
    }
    public void use()
    {
        useMedKit();
    }
}
