using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler
{
    public Item item;
    private Image _spriteImage;
    private UIItem _selectedItem;

    private void Awake()
    {
        _selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        _spriteImage = GetComponent<Image>();
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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.item != null)
        {
            if (_selectedItem.item != null)
            {
                Item clone = new Item(_selectedItem.item);
                _selectedItem.UpdateItem(this.item);
                UpdateItem(clone);
            } else
            {
                _selectedItem.UpdateItem(this.item);
                UpdateItem(null);
            }
        } else
        {
            UpdateItem(_selectedItem.item);
            _selectedItem.UpdateItem(null);
        }
    }
}
