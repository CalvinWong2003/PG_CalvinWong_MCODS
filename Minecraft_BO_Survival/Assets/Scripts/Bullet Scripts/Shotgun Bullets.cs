using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullets :Bullet
{


    // Start is called before the first frame update
    void Start()
    {   
        damage = 10;
        speed = 45f;
        lifetime = 5f;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision); // Call base class implementation
    }
}
