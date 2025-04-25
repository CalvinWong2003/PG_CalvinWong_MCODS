using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet :Bullet
{


    // Start is called before the first frame update
    void Start()
    {    
        damage = 100;
        speed = 40f;
        lifetime = 7.5f;
        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision); // Call base class implementation
    }
}
