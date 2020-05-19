using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class WinConditions 
{
    private BitArray _conditions;
    public BitArray conditions
    {
        get => _conditions;
    }
}
