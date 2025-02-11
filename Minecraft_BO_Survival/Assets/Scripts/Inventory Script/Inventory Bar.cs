using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{
    //References to the Image components for the 4 inventory slots
    public Image Slot_1;
    public Image Slot_2;
    public Image Slot_3;
    public Image Slot_4;
    public Image Slot_5;

    //Color change when selected
    private Color defaultColor = Color.gray;
    private Color selectedColor = Color.white;
    private Image selectedSlot = null;
    CharacterControllerScript thePlayer;

    private void Start()
    {
        thePlayer =FindObjectOfType<CharacterControllerScript>();
        SelectSlot(Slot_1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(Slot_1, 1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(Slot_2, 2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(Slot_3, 3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(Slot_4, 4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(Slot_5, 5);
        }
    }

    void SelectSlot(Image slot, int objectIndex)
    {
        if(selectedSlot == slot)
        {
            return;
        }
        DeselectAllSlots();
        selectedSlot = slot;
        selectedSlot.color = selectedColor;
        thePlayer.selectItem(objectIndex);
    }

    void DeselectAllSlots()
    {
        Slot_1.color = defaultColor;
        Slot_2.color = defaultColor;
        Slot_3.color = defaultColor;
        Slot_4.color = defaultColor;
        Slot_5.color = defaultColor;
    }
}
