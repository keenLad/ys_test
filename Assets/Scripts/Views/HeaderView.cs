using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderView : MonoBehaviour
{
    [SerializeField]
    Text _moneyLabel;

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
}
