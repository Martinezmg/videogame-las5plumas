using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New level progress", menuName = "Levels/Level")]
public class LevelProgress : ScriptableObject
{
    [SerializeField]
    private bool isActive = false;

    public Color lvlColor;

    [SerializeField]
    private bool shard = false;
    [SerializeField]
    private bool coin1 = false;
    [SerializeField]
    private bool coin2 = false;
    [SerializeField]
    private bool coin3 = false;
    [SerializeField]
    private bool coin4 = false;
    [SerializeField]
    private bool coin5 = false;

    #region Properties
    public bool Shard
    {
        get
        {
            return shard;
        }

        set
        {
            shard = value;
            LVLUpdate();
        }
    }

    public bool Coin1
    {
        get
        {
            return coin1;
        }

        set
        {
            coin1 = value;
            LVLUpdate();
        }
    }

    public bool Coin2
    {
        get
        {
            return coin2;
        }

        set
        {
            coin2 = value;
            LVLUpdate();
        }
    }

    public bool Coin3
    {
        get
        {
            return coin3;
        }

        set
        {
            coin3 = value;
            LVLUpdate();
        }
    }

    public bool Coin4
    {
        get
        {
            return coin4;
        }

        set
        {
            coin4 = value;
            LVLUpdate();
        }
    }

    public bool Coin5
    {
        get
        {
            return coin5;
        }

        set
        {
            coin5 = value;
            LVLUpdate();
        }
    }

    public bool IsActive
    {
        get
        {
            return isActive;
        }

        set
        {
            isActive = value;
            LVLUpdate();
        }
    }
    #endregion

    public event Action LvlUpdated;

    private void LVLUpdate()
    {
        if (LvlUpdated != null)
        {
            LvlUpdated();
        }
    }
}
