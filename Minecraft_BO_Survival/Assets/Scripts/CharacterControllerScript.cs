using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float speed = 5f;



    private Rigidbody rb;
    IUsable currentObject;
    List<IUsable> allObjects;
    int currentObjectIndex = 0;
    I_InventoryBar currentSlot;
    List<I_InventoryBar> allSlots;
    int currentSlotIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        allObjects = GetComponents<IUsable>().ToList();
        rb = GetComponent<Rigidbody>();
        allSlots = GetComponents<I_InventoryBar>().ToList();
        currentObject = allObjects[currentObjectIndex];
        currentSlot = allSlots[currentSlotIndex];
    }
    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))

        {
            currentObjectIndex += 1;
            currentObjectIndex = currentObjectIndex % allObjects.Count;
            currentObject = allObjects[currentObjectIndex];

            
        }
        MovePlayer();

        if (Input.GetMouseButtonDown(0))
        {
            currentObject.use();
        }
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

