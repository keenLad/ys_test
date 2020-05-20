using System;
using UnityEngine;


public class SlotItem : MonoBehaviour
{
    public event Action<bool> OnWinChaged;
    public int id;
    public Sprite originSprite;
    public Sprite blureSprite;

    private bool _isWin;
    public bool IsWin
    {
        get => _isWin;
        set
        {
            _isWin = value;
            OnWinChaged?.Invoke(_isWin);
        }
    }
}
