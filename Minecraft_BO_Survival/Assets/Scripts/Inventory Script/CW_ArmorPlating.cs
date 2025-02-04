using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_ArmorPlating : MonoBehaviour, IUsable
{
    private string name;
    private string description;
    private float armorAmount;
    private float numberOfUses;

    internal void useArmorPlating()
    {
        Debug.Log("Using armor plating to reinforce myself");
    }
    internal void armorPlatingAttributes(string name, string description, float armorAmount, float numberOfUses)
    {
        name = "Iron chestplate";
        description = "A durable iron chestplate that is worn to protect itself from danger";
        armorAmount = 50f;
        numberOfUses = 2f;
    }

    public void use()
    {
        useArmorPlating();
    }
}
