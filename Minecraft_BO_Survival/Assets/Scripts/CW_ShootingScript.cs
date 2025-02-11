using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_ShootingScript : MonoBehaviour, IUsable
{
    [Tooltip("The sphere prefab used as the projectile")]
    public GameObject spherePrefab;

    [Tooltip("The transform from where the projectile is spawned")]
    public Transform AttackPoint;

    [Tooltip("Projectile speed when fired")]
    public float bulletSpeed = 20f;

    [Tooltip("Time (in seconds) before you can fire again")]
    public float reloadTime = 4f;

    [Tooltip("Magazine capacity (number of rounds left before reload)")]
    public int magazineCapacity = 30;

    [Tooltip("Time (in seconds) between shots when holding down the fire button.")]
    public float fireRate = 12.5f;

    private int currentAmmo;
    private float nextFireRate;
    private bool isReloading;

    void Start()
    {
        currentAmmo = magazineCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isReloading && Time.time >= nextFireRate)
        {
            if(currentAmmo > 0)
            {
                Shoot();
                nextFireRate = Time.time + fireRate;
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }

    void Shoot()
    {
        GameObject sphere = Instantiate(spherePrefab, AttackPoint.position, AttackPoint.rotation);

        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb = sphere.AddComponent<Rigidbody>();
        }

        rb.velocity = AttackPoint.forward * bulletSpeed;

        currentAmmo--;
        Debug.Log("Shots Fired! Ammo remaing: " + currentAmmo);

        if(currentAmmo < 0)
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

    public void use()
    {
        Shoot();
    }
}
