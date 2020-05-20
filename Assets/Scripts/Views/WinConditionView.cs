using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConditionView : MonoBehaviour
{
    [SerializeField]
    Transform _positionContainer;
    [SerializeField]
    Toggle _positionItem;

    [SerializeField]
    Transform _rateContainer;
    [SerializeField]
    RateItemView _rateItem;



    public WinConditions conditions;
    private int _slotsCount;


    public void Init(WinConditions conditions, int slotsCount = 5)
    {
        this.conditions = conditions;
        _slotsCount = slotsCount;
        FillData();
    }



    public void AddRate()
    {
        RateItemView item = Instantiate(_rateItem, _rateContainer);
        WinRate rate = new WinRate();
        rate.count = 3;
        rate.rate = 1.5f;

        item.rateItem = rate;
        conditions._winRate.Add(rate);

        item.OnDelete += OnDeleteRateHandler;
        item.gameObject.SetActive(true);
    }

    private void OnDeleteRateHandler(WinRate rate)
    {
        conditions._winRate.Remove(rate);
    }

    private void FillData()
    {
        _rateContainer.ClearAll();
        foreach(var rate in conditions._winRate)
        {
            RateItemView item = Instantiate(_rateItem, _rateContainer);
            item.rateItem = rate;
            item.gameObject.SetActive(true);
        }

        _positionContainer.GetComponent<GridLayoutGroup>().constraintCount = _slotsCount;

        _positionContainer.ClearAll();
        for (int i = 0; i < conditions._conditions.Length; i++)
        {
            Toggle item = Instantiate(_positionItem, _positionContainer);
            item.name = i.ToString();
            item.isOn = conditions._conditions[i];
            item.gameObject.SetActive(true);
            item.onValueChanged.AddListener(OnPositionItemChangedHandler);
        }
    }

    private void OnPositionItemChangedHandler(bool value)
    {
        for(int i = 0; i < _positionContainer.childCount; i++)
        {
            Toggle item = _positionContainer.GetChild(i).GetComponent<Toggle>();
            conditions._conditions[i] = item.isOn;

        }
    }


}
