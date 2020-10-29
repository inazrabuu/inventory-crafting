using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlotPanel : MonoBehaviour
{
    private CraftRecipeDatabase _craftRecipeDatabase;
    private List<UIItem> _uiItems = new List<UIItem>();
    public UIItem craftResultSlot;

    private void Start()
    {
        _craftRecipeDatabase = FindObjectOfType<CraftRecipeDatabase>();
        _uiItems = GetComponent<SlotPanel>().uiItems;
        _uiItems.ForEach(i => i.craftingSlot = true);
    }

    public void UpdateRecipe()
    {
        int[] itemTable = new int[_uiItems.Count];
        for (int i = 0; i < _uiItems.Count; i++)
        {
            if (_uiItems[i].item != null)
            {
                itemTable[i] = _uiItems[i].item.id;
            }
        }

        Item itemToCraft = _craftRecipeDatabase.CheckRecipe(itemTable);
        UpdateCraftingResultSlot(itemToCraft);
    }

    void UpdateCraftingResultSlot(Item itemToCraft)
    {
        craftResultSlot.UpdateItem(itemToCraft);
    }
}
