using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    private Image _spriteImage;
    private UIItem _selectedItem;
    public bool craftingSlot;
    private CraftingSlotPanel _craftingSlotPanel;
    [SerializeField]
    private bool _craftingResultSlot;
    private Tooltip _tooltip;

    private void Awake()
    {
        _craftingSlotPanel = FindObjectOfType<CraftingSlotPanel>();
        _selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        _spriteImage = GetComponent<Image>();
        _tooltip = FindObjectOfType<Tooltip>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            _spriteImage.color = Color.white;
            _spriteImage.sprite = this.item.icon;
        } else
        {
            _spriteImage.color = Color.clear;
        }

        if (craftingSlot)
        {
            _craftingSlotPanel.UpdateRecipe();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            UICraftResult craftResult = GetComponent<UICraftResult>();
            if (craftResult != null && this.item != null && _selectedItem.item == null)
            {
                craftResult.PickItem();
                _selectedItem.UpdateItem(this.item);
                craftResult.ClearSlots();
            } else if (!_craftingResultSlot)
            {
                if (_selectedItem.item != null)
                {
                    Item clone = new Item(_selectedItem.item);
                    _selectedItem.UpdateItem(this.item);
                    UpdateItem(clone);
                }
                else
                {
                    _selectedItem.UpdateItem(this.item);
                    UpdateItem(null);
                }
            }
        } else if (_selectedItem.item != null && !_craftingResultSlot)
        {
            UpdateItem(_selectedItem.item);
            _selectedItem.UpdateItem(null);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {
            _tooltip.GenerateTooltip(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _tooltip.gameObject.SetActive(false);
    }
}
