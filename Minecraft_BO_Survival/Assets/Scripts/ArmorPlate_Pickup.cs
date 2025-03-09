using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPlate_Pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CW_ArmorPlating armorPlateNumber = other.GetComponent<CW_ArmorPlating>();
            if(armorPlateNumber != null)
            {
                armorPlateNumber.numberOfUses += 1;
                Destroy(gameObject);
            }
        }
    }
}
