using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3;
    public float jumpSpeed = 10f;
    public float gravity = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
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
    }
}

