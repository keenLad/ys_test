using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RateItemView : MonoBehaviour
{
    public event Action<WinRate> OnDelete;

    [SerializeField]
    InputField _count;
    [SerializeField]
    InputField _rate;

    private WinRate _rateItem;

    public WinRate rateItem
    {
        get => _rateItem;
        set
        {
            _rateItem = value;
            _count.text = _rateItem.count.ToString();
            _rate.text = _rateItem.rate.ToString();
        }
    }

    private void Start()
    {
        _rate.onEndEdit.AddListener(ApplyChanges);
        _count.onEndEdit.AddListener(ApplyChanges);
    }

    private void ApplyChanges(string value)
    {
        rateItem.count = int.Parse(_count.text);
        rateItem.rate = float.Parse(_rate.text);
    }


    public void Delete()
    {
        OnDelete?.Invoke(rateItem);
        Destroy(gameObject);
    }
}
