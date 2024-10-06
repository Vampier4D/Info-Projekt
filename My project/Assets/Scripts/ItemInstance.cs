using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    public int condition;
    public int rarity;
    public bool usedCondition;

    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
        rarity = itemData.baseRarity;
        usedCondition = itemData.useCondition;
        condition = itemData.startingCondition;
        
    }
   
}
