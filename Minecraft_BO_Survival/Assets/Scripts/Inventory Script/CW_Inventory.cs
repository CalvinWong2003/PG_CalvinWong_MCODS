using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CW_Inventory
{
    internal List<CW_InventoryItems> listOfInventory;

    internal void addItems(CW_InventoryItems item)
    {
        listOfInventory.Add(item);
    }

    internal void removeItems(CW_InventoryItems item)
    {
        listOfInventory.Remove(item);
    }

    internal CW_InventoryItems getItems(int index)
    {
        CW_InventoryItems item = listOfInventory[index];
        return item;
    }
}
