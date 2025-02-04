using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour, I_InventoryBar
{
    //References to the Image components for the 4 inventory slots
    public Image Slot_1;
    public Image Slot_2;
    public Image Slot_3;
    public Image Slot_4;

    //Color change when selected
    private Color defaultColor = Color.white;
    private Color selectedColor = Color.green;
    private Image selectedSlot = null;
    private MonoBehaviour selectedItemScript = null;


    // Update is called once per frame
    void UpdateInventory()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(Slot_1, Slot_1.GetComponent<CW_IronSword>());
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(Slot_2, Slot_2.GetComponent<CW_ArmorPlating>());
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(Slot_3, Slot_3.GetComponent<CW_MedKit>());
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(Slot_4, Slot_4.GetComponent<CW_HandGrenade>());
        }

        if(Input.GetKeyDown(KeyCode.E) && selectedItemScript != null)
        {
            UseSelectedItem();
        }
    }

    void SelectSlot(Image slot, MonoBehaviour itemScript)
    {
        if(selectedSlot == slot)
        {
            return;
        }
        DeselectAllSlots();
        selectedSlot = slot;
        selectedItemScript = itemScript;
        selectedSlot.color = selectedColor;
    }

    void DeselectAllSlots()
    {
        Slot_1.color = defaultColor;
        Slot_2.color = defaultColor;
        Slot_3.color = defaultColor;
        Slot_4.color = defaultColor;
    }

    void UseSelectedItem()
    {
        if(selectedItemScript is CW_IronSword ironSword)
        {
            ironSword.swingSword();
        }
        else if(selectedItemScript is CW_ArmorPlating ironChestPlate)
        {
            ironChestPlate.useArmorPlating();
        }
        else if(selectedItemScript is CW_MedKit medicalKit)
        {
            medicalKit.useMedKit();
        }
        else if(selectedItemScript is CW_HandGrenade handGrenade)
        {
            handGrenade.useHandGrenade();
        }
    }

    public void useSlot()
    {
        UpdateInventory();
    }
}
