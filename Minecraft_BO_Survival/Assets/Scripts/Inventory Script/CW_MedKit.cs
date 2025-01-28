using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_MedKit : CW_InventoryItems
{
    private float healAmount;
    private float numberOfUses;

    internal void useMedKit()
    {
        if(Input.GetKey(KeyCode.I))
        {
            Debug.Log("Using MedKit to heal myself");
        }
    }
    internal void MedKitAttributes(string name, string description, float healAmount, float numberOfUses)
    {
        name = "Medical Kit";
        description = "A medical kit containing medical supplements, used to heal the wounded";
        healAmount = 50f;
        numberOfUses = 2;
    }
}
