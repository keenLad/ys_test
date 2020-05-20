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

    public Slot slot
    {
        get => _slot;
    }


    public void Init(int rows = 3)
    {
        Slot slot = gameObject.GetComponent<Slot>();
        _slot = slot;
        _slot.itemsCount = rows;
        _slot.OnValueChanged += OnSlotChanged;
        UpdateSlot();
    }

    private void OnSlotChanged(Slot slot)
    {
        _itemsConteainer.ClearAll();
        foreach (var item in slot.Content)
        {
            SlotItemView slotItem = Instantiate(_itemPrefab, _itemsConteainer);
            slotItem.Init(item);
        }
    }

    public void UpdateSlot()
    {
        _slot.FillByItems();
    }

}
