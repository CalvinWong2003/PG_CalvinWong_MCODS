using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_ArmorPlating : MonoBehaviour, IUsable
{
    public GameObject Player;
    Image Blue;
    float numberOfUses;
    float numberOfUseLimit = 2f;
    internal int healArmorAmount = 25;

    public void AddUse()
    {
        numberOfUses++;
    }

    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        foreach (Image i in images)
        {
            if(i.name == "Blue")
            {
                Blue = i;
            }
        }
        numberOfUses = numberOfUseLimit;
    }

    internal void useArmorPlating()
    {
        Debug.Log("Using armor plating to reinforce myself");
        for(int i = 0; i < numberOfUses; i++)
        {
            if(numberOfUses > 0)
            {
                PlayerHealthArmor playerArmor = Player.GetComponent<PlayerHealthArmor>();
                if(playerArmor != null)
                {
                    playerArmor.Heal(healArmorAmount);
                    numberOfUses--;
                }
                Debug.Log("Number of Armor Plates left: " + numberOfUses);
            }
            else
            {
                Debug.Log("No Armor Plates available!!!");
            }
        }
    }

    public void use()
    {
        useArmorPlating();
    }
}
