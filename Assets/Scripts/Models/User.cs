using System;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    private static User _instace;

    public static User instance
    {
        get => _instace;
    }

    public User()
    {
        _instace = this;
    }

    public event Action<float> OnMoneyChange;

    float _money = 100;
    public float money
    {
        get => _money;
        set
        {
            _money = value;
            OnMoneyChange?.Invoke(_money);

        }
    }
}
