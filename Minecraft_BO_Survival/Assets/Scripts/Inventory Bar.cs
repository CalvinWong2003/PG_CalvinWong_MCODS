using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{
    public string[] inventory = new string[5];
    public Image[] slotImages;
    private int selectedSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventory[0] = "Health Potion";
        inventory[1] = "Medical Kit";
        inventory[2] = "Iron Sword";
        inventory[3] = "Diamond Chestplate";
        inventory[4] = "Ballistic Shield";

        UpdateInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }
    }

    private void SelectSlot(int slotIndex)
    {
        if(slotIndex >= 0 && slotIndex < inventory.Length)
        {
            selectedSlot = slotIndex;
            UpdateInventoryUI();
        }
    }

    private void UpdateInventoryUI()
    {
        for(int i = 0; i < slotImages.Length; i++)
        {
            if(i == selectedSlot)
            {
                slotImages[i].color = Color.green;
            }
            else
            {
                slotImages[i].color = Color.white;
            }
        }
    }
}
