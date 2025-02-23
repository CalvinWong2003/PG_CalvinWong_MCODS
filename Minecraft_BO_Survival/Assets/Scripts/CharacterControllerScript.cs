using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerScript : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    IUsable currentObject;
    List<IUsable> allObjects;
    int currentObjectIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        allObjects = GetComponents<IUsable>().ToList();
        rb = GetComponent<Rigidbody>();
        currentObject = allObjects[currentObjectIndex];
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentObject.use();
        }
        
        MovePlayer();
    }

    internal void selectItem(int index)
    {
        currentObjectIndex = index;
        currentObject = allObjects[currentObjectIndex];
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

