using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotPanel : MonoBehaviour
{
    public List<UIItem> uiItems = new List<UIItem>();
    public int numberOfSlots;
    private GameObject _slotPrefab;

    void Awake()
    {
        _slotPrefab = Resources.Load<GameObject>("Prefabs/Slot");

        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(_slotPrefab);
            instance.transform.SetParent(transform);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
            uiItems[i].item = null;
        }
    }

    public void UpdateItem(int slot, Item item)
    {
        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateItem(uiItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateItem(uiItems.FindIndex(i => i.item == item), null);
    }

    public bool ContainsEmptySlot()
    {
        foreach (UIItem uii in uiItems)
        {
            if (uii.item == null) return true;
        }

        return false;
    }
}
