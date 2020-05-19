using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineView : MonoBehaviour
{
    public int _slotsCount = 5;
    public int _rowCount = 3;



    [SerializeField]
    WinConditions _conditions;

    [SerializeField]
    SlotView _slotPrefab;
    [SerializeField]
    Transform _slotsContainer;

    [SerializeField]
    Dropdown _betDropdown;



    List<SlotView> _slots = new List<SlotView>();

    private void Start()
    {
        for (int i = 0; i < _slotsCount; i++)
        {
            SlotView slotView = Instantiate(_slotPrefab, _slotsContainer);
            _slots.Add(slotView);
            slotView.Init(_rowCount);
        }
    }

    public void Roll()
    {
        var selectedItem = _betDropdown.value;
        int bet = int.Parse(_betDropdown.options[selectedItem].text);

        if (User.instance.money < bet)
        {
            return;
        }

        User.instance.money -= bet;

        foreach (var item in _slots)
        {
            item.UpdateSlot();
        }

        CheckWins();
    }

    public void UpdateMachine()
    {
        _slots.Clear();
        _slotsContainer.ClearAll();

        Start();
    }

    void CheckWins()
    {
        List<SlotItem> result = new List<SlotItem>();
        foreach (var item in _slots)
        {
            result.Add(item.slot.Content[1]);
        }

        var ranking = (from item in result
                       group item by item.id into r
                       orderby r.Count() descending
                       select new { item = r.Key, count = r.Count() }).ToArray();

        if (ranking[0].count >= 3)
        {
            var selectedItem = _betDropdown.value;
            int bet = int.Parse(_betDropdown.options[selectedItem].text);

            User.instance.money += bet * 1.5f;
        }


    }


}
