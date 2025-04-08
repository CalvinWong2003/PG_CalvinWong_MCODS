using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MedKitPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Collider[] pickupItems = Physics.OverlapSphere(transform.position, 1f);
        foreach(Collider p in pickupItems)
        {
            if (other.CompareTag("Player"))
            {
                CW_MedKit playerUses = other.GetComponent<CW_MedKit>();
                if (playerUses != null)
                {
                    playerUses.AddUse();
                }

                GameController pickupSpawner = FindObjectOfType<GameController>();
                if (pickupSpawner != null)
                {
                    pickupSpawner.StartRespawnTimer(transform.parent.GetSiblingIndex());
                }
                Destroy(gameObject);
            }
        }
    }
}
