using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullets : MonoBehaviour
{
    public float damage = 50f;
    public float speed = 30f;
    public float lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
