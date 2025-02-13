using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{
    //References to the Image components for the 5 inventory slots
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
        SelectSlot(Slot_1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(Slot_1, 0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(Slot_2, 1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(Slot_3, 2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(Slot_4, 3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(Slot_5, 4);
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
