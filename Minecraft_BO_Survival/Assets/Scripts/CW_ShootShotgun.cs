using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class CW_ShootShotgun : MonoBehaviour, IUsable
{

    public GameObject ShotgunBullets;
    Transform AttackPoint;
     float bulletSpeed = 45f;
    int pelletCount = 5;
     float spreadAngle = 45f;

    [Tooltip("Time (in seconds) before you can fire again")]
    public float reloadTime = 4f;

    [Tooltip("Magazine capacity (number of rounds left before reload)")]
    public int magazineCapacity = 8;

    private int currentAmmo;
    private bool isReloading = false;

    void Start()
    {
        Transform[] allTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform t in allTransforms)
        {
            if (t.name == "AttackPoint")
            {
                AttackPoint = t;
            }
        }
        currentAmmo = magazineCapacity;
    }

    void ShootShotgun()
    {
        currentAmmo--;
        Debug.Log("Shots Fired! Ammo remaing: " + currentAmmo);

        if (currentAmmo < 0)
        {
            StartCoroutine(Reload());
        }
        //Instantiates a total of 5 pellets in a cone angle
        for (int i = 0; i < pelletCount; i++)
        {

            // Convert the cone angle to radians
            float halfAngleRad = Mathf.Deg2Rad * spreadAngle / 2f;

            // Generate a random direction within the cone
            float randomTheta = Random.Range(0f, 2f * Mathf.PI);
            float randomPhi = Random.Range(0f, halfAngleRad);

            // Create a random axis of rotation
            Vector3 randomAxis = new Vector3(
                Mathf.Sin(randomPhi) * Mathf.Cos(randomTheta),
                Mathf.Sin(randomPhi) * Mathf.Sin(randomTheta),
                Mathf.Cos(randomPhi)
            );

            // Create a random rotation based on the axis
            Quaternion rotationInCone = Quaternion.AngleAxis(spreadAngle / 2f, randomAxis);

            Quaternion bulletForward = Quaternion.LookRotation(Camera.main.transform.forward) * rotationInCone;

            GameObject shotgunBullet = Instantiate(ShotgunBullets, AttackPoint.position,bulletForward);

            Rigidbody rb = shotgunBullet.GetComponent<Rigidbody>();
            if(rb == null)
            {
                rb = shotgunBullet.AddComponent<Rigidbody>();
            }
            rb.velocity = shotgunBullet.transform.forward * bulletSpeed;
        }
    }

    void Update()
    {
        Vector3 worldForward = transform.TransformDirection(transform.forward);
        print(Camera.main.transform.forward);
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineCapacity;
        isReloading = false;
        Debug.Log("Reload complete!");
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
