using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class CW_ShootShotgun : MonoBehaviour, IUsable
{

    public GameObject ShotgunBullets;
    Transform attackPoint;
    public float bulletSpeed = 30f;
    public int pelletCount = 5;
    public float spreadAngle = 10f;

    [Tooltip("Time (in seconds) before you can fire again")]
    public float reloadTime = 4f;

    [Tooltip("Magazine capacity (number of rounds left before reload)")]
    public int magazineCapacity = 8;

    private int currentAmmo;
    private float nextFireRate;
    private bool isReloading;

    void Start()
    {
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform t in allTransforms)
        {
            if (t.name == "AttackPoint")
            {
                attackPoint = t;
            }
        }
        currentAmmo = magazineCapacity;
    }

    void ShootShotgun()
    {
        for(int i = 0; i < pelletCount; i++)
        {
            float angle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 shootDirection = rotation * attackPoint.forward;

            GameObject shotgunBullet = Instantiate(ShotgunBullets, attackPoint.position, Quaternion.identity);

            Rigidbody rb = shotgunBullet.GetComponent<Rigidbody>();
            if(rb == null)
            {
                rb.velocity = shootDirection * bulletSpeed;
            }
        }
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

    public void use()
    {
        if (currentAmmo > 0)
        {
            ShootShotgun();
        }
        else
        {
            StartCoroutine(Reload());
        }
    }
}
