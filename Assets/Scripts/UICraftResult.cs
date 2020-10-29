using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftResult : MonoBehaviour
{
    private SlotPanel _slotPanel;
    private Inventory _inventory;

    private void Awake()
    {
        _slotPanel = GameObject.Find("CraftingPanel").GetComponentInChildren<SlotPanel>();
        _inventory = FindObjectOfType<Inventory>();
    }

    public void PickItem()
    {
        _inventory.playerItems.Add(GetComponent<UIItem>().item);
    }

    public void ClearSlots()
    {
        _slotPanel.EmptyAllSlots();
    }
}
