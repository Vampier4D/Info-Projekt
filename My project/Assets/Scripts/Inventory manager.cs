using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventoryDisplay : MonoBehaviour
{
    public static ItemDisplay[] slots;
    public DynamicInventory inventory;
    
    private void Start()
    {
        UpdateInventory();
    }

    void UpdateInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].UpdateItemDisplay(inventory.items[i].itemType.icon, i);
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }
}