using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderView : MonoBehaviour
{
    [SerializeField]
    Text _moneyLabel;
    [SerializeField]
    InputField _slotsLabel;
    [SerializeField]
    InputField _rowsLabel;

    [SerializeField]
    SlotMachineView _slotMachine;

    User _user;

    private void Awake()
    {
        _user = new User();
        _user.OnMoneyChange += OnMoneyChangeHandler;
    }

    private void OnMoneyChangeHandler(float obj)
    {
        _moneyLabel.text = obj.ToString();
    }

    private void Start()
    {
        _slotsLabel.SetTextWithoutNotify(_slotMachine._slotsCount.ToString());
        _rowsLabel.SetTextWithoutNotify(_slotMachine._rowCount.ToString());
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
    }
}
