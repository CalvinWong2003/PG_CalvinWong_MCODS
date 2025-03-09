using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit_pickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CW_MedKit medkitNumber = other.GetComponent<CW_MedKit>();
            if(medkitNumber != null)
            {
                medkitNumber.numberOfUses += 1;
                Destroy(gameObject);
            }
        }
    }
}
