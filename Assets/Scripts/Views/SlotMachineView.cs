using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineView : MonoBehaviour
{
    public int _slotsCount = 5;
    public int _rowCount = 3;


    public List<WinConditions> _conditions = new List<WinConditions>();

    [SerializeField]
    SlotView _slotPrefab;
    [SerializeField]
    Transform _slotsContainer;

    [SerializeField]
    Dropdown _betDropdown;

    List<SlotView> _slots = new List<SlotView>();

    private void Awake()
    {
        WinConditions initCondition = new WinConditions();
        initCondition._conditions = new System.Collections.BitArray(new bool[] {false, false, false, false, false,
                                                                                true, true, true, true, true,
                                                                                false, false, false, false, false });
        WinRate rate = new WinRate();
        rate.count = 3;
        rate.rate = 1.5f;
        initCondition._winRate.Add(rate);
        _conditions.Add(initCondition);
    }
    private void Start()
    {
        for (int i = 0; i < _slotsCount; i++)
        {
            SlotView slotView = Instantiate(_slotPrefab, _slotsContainer);
            _slots.Add(slotView);
            slotView.name = "slot_" + i;
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
        _conditions.Clear();
        
        Start();
    }

    void CheckWins()
    {
        float winValue = 0f;
        foreach (var condition in _conditions)
        {
            List<SlotItem> result = new List<SlotItem>();
            List<SlotItem> totaItems = new List<SlotItem>();

            for (int i = 0; i < _rowCount; i++)
            {
                for (int j = 0; j < _slotsCount; j++)
                {
                    totaItems.Add(_slots[j].slot.Content[i]);
                }

            }

            for (int i = 0; i < condition._conditions.Length; i++)
            {
                if(condition._conditions[i] == true)
                {
                    result.Add(totaItems[i]);
                }
            }

            var ranking = (from item in result
                           group item by item.id into r
                           orderby r.Count() descending
                           select new { item = r.Key, count = r.Count() }).ToArray();

            WinRate finalRate = null;

            foreach(var rate in condition._winRate)
            {
                if(rate.count <= ranking[0].count  && (finalRate == null || rate.count > finalRate.count))
                {
                    finalRate = rate;
                }
            }

            if (finalRate != null)
            {
                var selectedItem = _betDropdown.value;
                int bet = int.Parse(_betDropdown.options[selectedItem].text);

                Debug.LogFormat("win {1}: {0}", (bet * finalRate.rate), ranking[0].item);
                winValue += bet * finalRate.rate;
            }

        }

        Debug.Log("total: " + winValue);
        User.instance.money += winValue;


    }

    private System.Collections.IEnumerator SetWinned(List<SlotItem> items, int id)
    {
        yield return new WaitForEndOfFrame();

        foreach (var item in items)
        {
            if (item.id == id)
            {
                item.IsWin = true;
            }
        }

    }

}
