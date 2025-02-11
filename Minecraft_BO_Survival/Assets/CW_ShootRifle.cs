using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_ShootRifle : MonoBehaviour
{
    public GameObject bulletCloneTemplate;
    Transform AttackPoint;

    [Tooltip("Time (in seconds) before you can fire again")]
    public float reloadTime = 5.5f;

    [Tooltip("Magazine capacity (number of rounds left before reload)")]
    public int magazineCapacity = 30;

    private int currentAmmo;
    private float nextFireRate;
    private bool isReloading;

    float bulletSpeed = 30.5f;
    // Start is called before the first frame update
    void Start()
    {
        AttackPoint = transform.Find("AttackPoint");
        currentAmmo = magazineCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            if(currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }

    internal void Shoot()
    {
        GameObject sphere = Instantiate(bulletCloneTemplate,AttackPoint.position,AttackPoint.rotation);
        
        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = sphere.AddComponent<Rigidbody>();
        }

        rb.velocity = AttackPoint.forward * bulletSpeed;

        currentAmmo--;
        Debug.Log("Shots Fired! Ammo remaing: " + currentAmmo);

        if (currentAmmo < 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineCapacity;
        isReloading = false;
        Debug.Log("Reload complete! Ammo is refilled to " + currentAmmo);
    }
}
