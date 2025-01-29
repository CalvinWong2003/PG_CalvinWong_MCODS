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

    //References to the item scripts
    public CW_IronSword ironSword;
    public CW_ArmorPlating ironChestPlate;
    public CW_MedKit medicalKit;
    public CW_HandGrenade handGrenade;

    private int selectedSlot = 1;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(4);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            
        }

        UpdateInventoryUI();
    }

    void SelectSlot(int slot)
    {
        selectedSlot = slot;

        UpdateInventoryUI();
    }

    void UpdateInventoryUI()
    {
        Slot_1.sprite = null;
        Slot_2.sprite = null;
        Slot_3.sprite = null;
        Slot_4.sprite = null;

        switch(selectedSlot)
        {
            case 1:
                Slot_1.sprite = ironSword != null ? ironSword.GetComponent<SpriteRenderer>().sprite : null;
                break;
            
            case 2:
                Slot_2.sprite = ironChestPlate != null ? ironChestPlate.GetComponent<SpriteRenderer>().sprite : null;
                break;
            
            case 3:
                Slot_3.sprite = medicalKit != null ? medicalKit.GetComponent<SpriteRenderer>().sprite : null;
                break;
            
            case 4:
                Slot_4.sprite = handGrenade != null ? handGrenade.GetComponent<SpriteRenderer>().sprite : null;
                break;
        }
    }

    void UseSelectedItem()
    {
        switch(selectedSlot)
        {
            case 1:
                if(ironSword != null)
                {
                    ironSword.swingSword();
                }
                break;
                
            case 2:
                if(ironChestPlate != null)
                {
                    ironChestPlate.useArmorPlating();
                }
                break;

            case 3:
                if(medicalKit != null)
                {
                    medicalKit.useMedKit();
                }
                break;

            case 4:
                if(handGrenade != null)
                {
                    handGrenade.useHandGrenade();
                }
                break;
        }
    }
}
