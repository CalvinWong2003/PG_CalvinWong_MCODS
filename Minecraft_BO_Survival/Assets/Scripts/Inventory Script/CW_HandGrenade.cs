using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_HandGrenade : MonoBehaviour,IUsable
{
    public GameObject grenadePrefab;

    private GameObject spawnedGrenade;

    void ThrowGrenade()
    {
        if (grenadePrefab != null)
        {
            spawnedGrenade = Instantiate(grenadePrefab, transform.position + transform.forward, transform.rotation);
        }
        else 
        {
            Debug.LogError("Grenade Prefab or throw point not assigned");
        }
    }

    public void use()
    {
        ThrowGrenade();
    }
}
