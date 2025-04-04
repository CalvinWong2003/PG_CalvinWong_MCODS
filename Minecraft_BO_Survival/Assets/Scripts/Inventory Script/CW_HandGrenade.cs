using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_HandGrenade : MonoBehaviour,IUsable
{
    public GameObject grenadePrefab;
    float throwForce = 10f;
    float explosionDelay = 2f;
    float blastRadius = 3f;
    float AOEdamage = 100f;

    private GameObject spawnedGrenade;

    void Update()
    {

    }

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
