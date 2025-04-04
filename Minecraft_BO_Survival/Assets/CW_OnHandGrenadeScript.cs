using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_OnHandGrenadeScript : MonoBehaviour
{
    Rigidbody rb;
    private float throwForce = 5f;
    float grenadeTime = 2f;
    float timer;
    float blastRadius = 3f;
    int damage = 100;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.AddForce((transform.forward + transform.up) * throwForce, ForceMode.Impulse);

        timer = grenadeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Collider[] allVictims = Physics.OverlapSphere(transform.position, blastRadius);
            foreach(Collider c in allVictims)
            {
                IHealth damageable = c.GetComponent<IHealth>();
                if(damageable != null)
                {
                    damageable.takeDamage(damage);
                }
            }
            Destroy(gameObject);

            Debug.Log("BOOM");
        }
    }
}
