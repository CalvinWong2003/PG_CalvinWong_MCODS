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

    //Items to select and activate upon selection
    public GameObject AK47;
    public GameObject IronSword;
    public GameObject ArmorPlate;
    public GameObject MedKit;
    public GameObject handGrenade;

    private void Start()
    {
        thePlayer =FindObjectOfType<CharacterControllerScript>();
        SelectSlot(Slot_1, 0);
        if(AK47 != null)
        {
            AK47.SetActive(true);
        }
        if(IronSword != null)
        {
            IronSword.SetActive(false);
        }
        if(ArmorPlate != null)
        {
            ArmorPlate.SetActive(false);
        }
        if(MedKit != null)
        {
            MedKit.SetActive(false);
        }
        if(handGrenade != null)
        {
            handGrenade.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(Slot_1, 0);
            if(AK47 != null)
            {
                AK47.SetActive(true);
            }
            if(IronSword != null)
            {
                IronSword.SetActive(false);
            }
            if(ArmorPlate != null)
            {
                ArmorPlate.SetActive(false);
            }
            if(MedKit != null)
            {
                MedKit.SetActive(false);
            }
            if(handGrenade != null)
            {
                handGrenade.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(Slot_2, 1);
            if(AK47 != null)
            {
                AK47.SetActive(false);
            }
            if(IronSword != null)
            {
                IronSword.SetActive(true);
            }
            if(ArmorPlate != null)
            {
                ArmorPlate.SetActive(false);
            }
            if(MedKit != null)
            {
                MedKit.SetActive(false);
            }
            if(handGrenade != null)
            {
                handGrenade.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(Slot_3, 2);
            if(AK47 != null)
            {
                AK47.SetActive(false);
            }
            if(IronSword != null)
            {
                IronSword.SetActive(false);
            }
            if(ArmorPlate != null)
            {
                ArmorPlate.SetActive(true);
            }
            if(MedKit != null)
            {
                MedKit.SetActive(false);
            }
            if(handGrenade != null)
            {
                handGrenade.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(Slot_4, 3);
            if(AK47 != null)
            {
                AK47.SetActive(false);
            }
            if(IronSword != null)
            {
                IronSword.SetActive(false);
            }
            if(ArmorPlate != null)
            {
                ArmorPlate.SetActive(false);
            }
            if(MedKit != null)
            {
                MedKit.SetActive(true);
            }
            if(handGrenade != null)
            {
                handGrenade.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(Slot_5, 4);
            if(AK47 != null)
            {
                AK47.SetActive(false);
            }
            if(IronSword != null)
            {
                IronSword.SetActive(false);
            }
            if(ArmorPlate != null)
            {
                ArmorPlate.SetActive(false);
            }
            if(MedKit != null)
            {
                MedKit.SetActive(false);
            }
            if(handGrenade != null)
            {
                handGrenade.SetActive(true);
            }
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
