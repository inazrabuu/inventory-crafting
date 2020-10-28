using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;
    private Image _spriteImage;
    private UIItem _selectedItem;

    private void Awake()
    {
        _selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();
        _spriteImage = GetComponent<Image>();
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
}
