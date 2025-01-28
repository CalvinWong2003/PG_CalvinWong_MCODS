using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_HandGrenade : MonoBehaviour
{
    private string name;
    private string description;
    private float attackPower;
    private float numberOfUses;

    internal void useHandGrenade()
    {
        Debug.Log("Throwing Grenade!!!");
    }

    internal void handGrenadeAttributes(string name, string description, float attackPower, float numberOfUses)
    {
        name = "";
        description = "";
        attackPower = 100f;
        numberOfUses = 4f;
    }
}
