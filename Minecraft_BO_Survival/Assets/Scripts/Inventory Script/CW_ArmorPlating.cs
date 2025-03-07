using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_ArmorPlating : MonoBehaviour, IUsable
{
    public GameObject Player;
    public Image Blue;
    public float numberOfUses = 2f;
    public int healArmorAmount = 25;

    void Update()
    {
        
    }

    internal void useArmorPlating()
    {
        Debug.Log("Using armor plating to reinforce myself");
        for(int i = 0; i < numberOfUses; i++)
        {
            if(numberOfUses > 0)
            {
                HealArmor();
                Debug.Log("Number of Armor Plates left: " + numberOfUses);
            }
            else
            {
                Debug.Log("No Armor Plates available!!!");
            }
            numberOfUses--;
        }
    }
    public void HealArmor()
    {
        PlayerHealthArmor playerArmor = Player.GetComponent<PlayerHealthArmor>();
        if(playerArmor != null)
        {
            playerArmor.UpdateArmorBar(healArmorAmount);
        }
    }

    public void use()
    {
        if (Input.GetMouseButtonDown(0))
        {
            useArmorPlating();
        }
    }
}
