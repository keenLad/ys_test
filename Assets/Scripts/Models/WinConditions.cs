using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WinConditions
{
    public BitArray _conditions;
    public List<WinRate> _winRate = new List<WinRate>();
}

public class WinRate
{
    public int count;
    public float rate;
}
