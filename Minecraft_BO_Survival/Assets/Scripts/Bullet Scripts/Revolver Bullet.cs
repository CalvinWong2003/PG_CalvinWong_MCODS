using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : Bullet
{

    // Start is called before the first frame update
    void Start()
    {
       
        damage = 45;
        speed = 40;
        lifetime = 5;
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
