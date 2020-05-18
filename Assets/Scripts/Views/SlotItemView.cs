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
        SetOriginItem();
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
