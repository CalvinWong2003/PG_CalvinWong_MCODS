using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CW_ArmorPlating : MonoBehaviour, IUsable
{
    public Image Blue;
    public int currentArmor = 100;
    public int maxArmor = 100;
    public int healArmorAmount = 25;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            useArmorPlating();
        }
    }

    internal void useArmorPlating()
    {
        Debug.Log("Using armor plating to reinforce myself");

        if(currentArmor < maxArmor)
        {
            currentArmor = Mathf.Min(currentArmor + healArmorAmount, maxArmor);

            if(Blue != null)
            {
                Blue.fillAmount = (float)currentArmor / maxArmor;
            }
            Debug.Log("Armor Plating used. Current Armor: " + currentArmor);
        }
        else
        {
            Debug.Log("Armor is already full, Armor Plating not used");
        }
    }
    

    public void use()
    {
        useArmorPlating();
    }
}
