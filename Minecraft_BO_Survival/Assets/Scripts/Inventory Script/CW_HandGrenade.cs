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

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach(Collider hit in hitColliders)
        {
            if(hit.CompareTag("Enemy"))
            {
                EnemyScript enemy = hit.GetComponent<EnemyScript>();
                if(enemy != null)
                {
                    enemy.TakeDamage(AOEdamage);
                }
                else
                {
                    Destroy(hit.gameObject);
                }
            }
        }
        Debug.Log("BOOM!!!");
        
        Destroy(grenade);
    }

    public void use()
    {
        ThrowGrenade();
    }
}
