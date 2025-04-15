using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_ArmorPlating : MonoBehaviour, IUsable
{
    public GameObject Player;
    Image Blue;
    float numberOfUses = 2f;
    float numberOfUseLimit;
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
        numberOfUseLimit = numberOfUses;
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
                }
                Debug.Log("Number of Armor Plates left: " + numberOfUses);
            }
            else
            {
                Debug.Log("No Armor Plates available!!!");
            }
            numberOfUses--;
        }
    }

    public void use()
    {
        useArmorPlating();
    }
}
