using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_HandGrenade : MonoBehaviour,IUsable
{
    private string name;
    private string description;
    private float attackPower;
    private float numberOfUses;

    public GameObject grenadePrefab;
    public float throwForce = 100f;

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

            StartCoroutine(ExplodeAfterDelay(spawnedGrenade, 3f));
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

    public void use()
    {
        ThrowGrenade();
    }
}
