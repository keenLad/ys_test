using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class SlotItemView : MonoBehaviour
{
    
    [ShowNonSerializedField]
    SlotItem _item;
    [SerializeField]
    private Image itemImage;

    public void Init(SlotItem item)
    {
        _item = item;
        _item.OnWinChaged += _item_OnWinChaged;
        SetOriginItem();
    }

    private void _item_OnWinChaged(bool obj)
    {
        itemImage.color = Color.green;
    }

    public void SetBlureItem()
    {
        itemImage.sprite = _item.blureSprite;
    }

    public void SetOriginItem()
    {
        itemImage.sprite = _item.originSprite;
    }

}
