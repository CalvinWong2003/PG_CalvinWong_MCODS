using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{
    public string[] inventory = new string[4];
    public Image[] inventorySlots;
    private int selectedSlot = 0;

    CW_Inventory item;

    // Start is called before the first frame update
    void Start()
    {
        item = new CW_Inventory();
        CW_IronSword ironSword = new CW_IronSword();
        CW_ArmorPlating ironChestplate = new CW_ArmorPlating();
        CW_MedKit medKit = new CW_MedKit();

        item.addItems(ironSword);
        item.addItems(ironChestplate);
        item.addItems(medKit);

        UpdateInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
            CW_InventoryItems nextItem = item.getItems(1);
            print(nextItem.name + "\n" + nextItem.description);

            if (Input.GetMouseButton(0))
            {
                (nextItem as CW_IronSword).swingSword();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
            CW_InventoryItems nextItem1 = item.getItems(2);
            print(nextItem1.name + "\n" + nextItem1.description);

            if (Input.GetMouseButton(0))
            {
                (nextItem1 as CW_ArmorPlating).useArmorPlating();
            }
        }

        UpdateInventoryUI();
    }

    void SelectSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= inventorySlots.Length)
        {
            return;
        }

        selectedSlot = slotIndex;
        UpdateInventoryUI();
    }

    void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            //inventorySlots[i].color == (i == selectedSlot) ? Color.green : Color.white;
        }
    }
}
