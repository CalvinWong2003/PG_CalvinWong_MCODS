using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_IronSword : CW_InventoryItems
{
    private float attackPower;
    private float durability;

    internal void swingSword()
    {
        if(Input.GetKey(KeyCode.U))
        {
            Debug.Log("Swinging sword!");
        }
    }

    internal void swordAttributes(string name, string description, float attackPower, float durability)
    {
        name = "Iron Sword";
        description = "A durable iron sword forged to kill the forces of evil";
        durability = 230f;
        attackPower = 5.5f;
    }
}
