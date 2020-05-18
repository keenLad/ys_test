using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SlotView : MonoBehaviour
{
    [ShowNonSerializedField]
    Slot _slot;
    [SerializeField]
    Transform _itemsConteainer;
    [SerializeField]
    SlotItemView _itemPrefab;


    public void Init(Slot slot)
    {
        _slot = slot;
        _slot.OnValueChanged += OnSlotChanged;
    }

    private void OnSlotChanged(Slot slot)
    {
        _itemsConteainer.ClearAll();
        foreach(var item in slot.Content)
        {
            SlotItemView slotItem = Instantiate(_itemPrefab, _itemsConteainer);
            slotItem.Init(item);
        }
    }

    private void Start()
    {
        Slot slot = gameObject.GetComponent<Slot>();
        Init(slot);
    }

    public void UpdateSlot()
    {
        _slot.FillByItems();
    }

}
