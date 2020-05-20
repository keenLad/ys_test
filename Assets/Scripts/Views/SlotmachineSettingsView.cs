using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotmachineSettingsView : MonoBehaviour
{
    [SerializeField]
    SlotMachineView _slotMachine;

    [SerializeField]
    InputField _slotsLabel;
    [SerializeField]
    InputField _rowsLabel;

    [SerializeField]
    Transform _conditionsContainer;
    [SerializeField]
    WinConditionView _conditionPrefab;

    private void Start()
    {
        Fill();
    }

    private void Fill()
    {
        _slotsLabel.SetTextWithoutNotify(_slotMachine._slotsCount.ToString());
        _rowsLabel.SetTextWithoutNotify(_slotMachine._rowCount.ToString());

        _conditionsContainer.ClearAll();
        foreach(var item in _slotMachine._conditions)
        {
            WinConditionView itemView = Instantiate(_conditionPrefab, _conditionsContainer);
            itemView.Init(item, _slotMachine._rowCount);
        }
    }

    public void AddCondition()
    {
        WinConditions condition = new WinConditions();
        condition._conditions = new BitArray(new bool[_slotMachine._slotsCount * _slotMachine._rowCount]);
        _slotMachine._conditions.Add(condition);

        Fill();

    }

    public void UpdateSlotMachine()
    {
        if (!string.IsNullOrEmpty(_slotsLabel.text))
        {
            _slotMachine._slotsCount = int.Parse(_slotsLabel.text);
        }

        if (!string.IsNullOrEmpty(_rowsLabel.text))
        {
            _slotMachine._rowCount = int.Parse(_rowsLabel.text);
        }
        _slotMachine.UpdateMachine();
        Fill();
    }
}
