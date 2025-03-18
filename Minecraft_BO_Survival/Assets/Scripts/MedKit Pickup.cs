using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
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
