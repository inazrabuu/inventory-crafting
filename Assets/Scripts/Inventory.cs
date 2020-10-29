using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> playerItems = new List<Item>();
    private ItemDatabase _itemDatabase;
    private UIInventory _uiInventory;

    private void Awake()
    {
        _itemDatabase = FindObjectOfType<ItemDatabase>();
        _uiInventory = FindObjectOfType<UIInventory>();
    }

    private void Start()
    {
        GiveItem(1);
        GiveItem(2);
        GiveItem(3);
        GiveItem(1);
        GiveItem(2);
        GiveItem(3);
        GiveItem(1);
        GiveItem(2);
        GiveItem(3);
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = _itemDatabase.GetItem(id);
        _uiInventory.AddItemToUI(itemToAdd);
        playerItems.Add(itemToAdd);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = _itemDatabase.GetItem(itemName);
        _uiInventory.AddItemToUI(itemToAdd);
        playerItems.Add(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
        }
    }
}
