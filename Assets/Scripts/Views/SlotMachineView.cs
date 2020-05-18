using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineView : MonoBehaviour
{
    [SerializeField]
    int _slotsCount = 5;
    [SerializeField]
    SlotView _slotPrefab;
    [SerializeField]
    Transform _slotsContainer;

    List<SlotView> _slots = new List<SlotView>();

    private void Start()
    {
        for (int i = 0; i < _slotsCount; i++)
        {
            SlotView slotView = Instantiate(_slotPrefab, _slotsContainer);
            _slots.Add(slotView);
        }
    }

    private void OnGUI()
    {
        if(GUILayout.Button("Update machine"))
        {
            _slots.Clear();
            _slotsContainer.ClearAll();

            Start();
        }

        if(GUILayout.Button("Roll"))
        {
            foreach(var item in _slots)
            {
                item.UpdateSlot();
            }
        }
    }


}
