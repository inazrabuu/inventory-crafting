using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField]
    private SlotPanel[] _slotPanels;

    public void AddItemToUI(Item item)
    {
        foreach (SlotPanel sp in _slotPanels)
        {
            if (sp.ContainsEmptySlot())
            {
                sp.AddNewItem(item);
                break;
            }
        }
    }
}
