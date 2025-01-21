using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private float speed = 3;
    float sensitivity = 0.1f;
    float sensitivity1 = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        transform.Rotate(Vector3.up,sensitivity* Input.GetAxis("Horizontal"));
        //transform.Rotate(Vector3.down, sensitivity1 * Input.GetAxis("Vertical"));
        
    }
}

