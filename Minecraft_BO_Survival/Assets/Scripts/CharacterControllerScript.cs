using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControllerScript : MonoBehaviour
{
    public float speed = 5f;

    //References to the Image components for the 4 inventory slots
    public Image Slot_1;
    public Image Slot_2;
    public Image Slot_3;
    public Image Slot_4;

    //Color change when selected
    private Color defaultColor = Color.gray;
    private Color selectedColor = Color.white;
    private Image selectedSlot = null;

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
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            currentObjectIndex += 1;
            currentObjectIndex = currentObjectIndex % allObjects.Count;
            currentObject = allObjects[currentObjectIndex];

            if(currentObjectIndex == 1)
            {
                SelectSlot(Slot_1);
            }
            if(currentObjectIndex == 2)
            {
                SelectSlot(Slot_2);
            }
            if(currentObjectIndex == 3)
            {
                SelectSlot(Slot_3);
            }
            if(currentObjectIndex == 4)
            {
                SelectSlot(Slot_4);
            }
        }
        if(Input.GetMouseButtonDown(0) && currentObjectIndex == 1)
        {
            currentObject.use();
        }
        if(Input.GetMouseButtonDown(0) && currentObjectIndex == 2)
        {
            currentObject.use();
        }
        if(Input.GetMouseButtonDown(0) && currentObjectIndex == 3)
        {
            currentObject.use();
        }
        if(Input.GetMouseButtonDown(0) && currentObjectIndex == 4)
        {
            currentObject.use();
        }
        
        MovePlayer();
    }

    void SelectSlot(Image slot)
    {
        if(selectedSlot == slot)
        {
            return;
        }
        DeselectAllSlots();
        selectedSlot = slot;
        selectedSlot.color = selectedColor;
    }

    void DeselectAllSlots()
    {
        Slot_1.color = defaultColor;
        Slot_2.color = defaultColor;
        Slot_3.color = defaultColor;
        Slot_4.color = defaultColor;
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

