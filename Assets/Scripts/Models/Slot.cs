using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NaughtyAttributes;

public class Slot : MonoBehaviour
{
    public event Action<Slot> OnValueChanged;

    [Serializable]
    public class ItemElement
    {
        public SlotItem item;
        [MinMaxSlider(0.0f, 100.0f)]
        public Vector2 chanse;
    }

    public int itemsCount = 3;
    [SerializeField]
    ItemElement[] items;

    [ShowNonSerializedField]
    private SlotItem[] _content;

    public SlotItem[] Content
    {
        get => _content;
    }

    private System.Random random = new System.Random();

    private void Start()
    {
        FillByItems();
    }

    public SlotItem[] FillByItems()
    {
        _content = new SlotItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            double shanse = random.NextDouble()*100;
            ItemElement newItem = items.FirstOrDefault(item => item.chanse.x < (float)shanse && (float)shanse < item.chanse.y);
            _content[i] = newItem.item;
            Debug.LogFormat("Chanse: {0} ||| Item: {1}", shanse, newItem.item.id);
        }

        OnValueChanged?.Invoke(this);
        return _content;
    }

}
