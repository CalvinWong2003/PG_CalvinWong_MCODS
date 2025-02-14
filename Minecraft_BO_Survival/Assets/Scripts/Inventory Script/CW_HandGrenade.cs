using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_HandGrenade : MonoBehaviour,IUsable
{
    public GameObject grenadePrefab;
    public float throwForce = 100f;
    public float AOEdamage = 100f;

    private GameObject spawnedGrenade;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && spawnedGrenade != null)
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        if (grenadePrefab != null)
        {
            spawnedGrenade = Instantiate(grenadePrefab, transform.position + 2* Vector3.right, transform.rotation);
            Rigidbody rb = spawnedGrenade.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddForce((transform.forward + Vector3.up) * throwForce, ForceMode.Impulse);
            }

            StartCoroutine(ExplodeAfterDelay(spawnedGrenade, 2f));
        }
        else 
        {
            Debug.LogError("Grenade Prefab or throw point not assigned");
        }
    }

    System.Collections.IEnumerator ExplodeAfterDelay(GameObject grenade, float delay)
    {
        yield return new WaitForSeconds(delay);

        Debug.Log("Boom! Grenade exploded.");
        Destroy(grenade);
    }

    public void use()
    {
        ThrowGrenade();
    }
}
