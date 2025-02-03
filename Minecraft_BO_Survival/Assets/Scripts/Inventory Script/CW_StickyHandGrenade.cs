using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_StickyHandGrenade : MonoBehaviour
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
        name = "Frag Grenade";
        description = "A deadly weapon used to wipe out a small crowds of enemies.";
        attackPower = 100f;
        numberOfUses = 4f;
    }
}
