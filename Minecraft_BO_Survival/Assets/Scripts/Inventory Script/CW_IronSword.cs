using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_IronSword : MonoBehaviour, IUsable
{
    private string name;
    private string description;
    private float attackPower;
    private float durability;

    public void use()
    {
        swingSword();
    }

    internal void swingSword()
    {
        Debug.Log("Swinging sword!");
    }

    internal void swordAttributes(string name, string description, float attackPower, float durability)
    {
        name = "Iron Sword";
        description = "A durable iron sword forged to kill the forces of evil";
        durability = 230f;
        attackPower = 5.5f;
    }
}
