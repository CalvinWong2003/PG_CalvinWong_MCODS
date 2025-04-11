using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    internal int damage = 30;
    internal float speed = 20;
    internal float lifetime = 5;

    // Start is called before the first frame update
    internal void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    internal void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        IHealth damageable = collision.gameObject.GetComponent<IHealth>();

        if (damageable != null)
        {
            damageable.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
