using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Project.Testing;

public class CheckShard : MonoBehaviour {

    private bool isShard = false;

    public StackeableContainer shardContainer;

    public UnityEvent ThereIsShard;
    public UnityEvent ThereNOTShard;

    private bool IsShard
    {
        get
        {
            return isShard;
        }

        set
        {
            isShard = value;

            if (isShard)
            {
                ThereIsShard.Invoke();
            }
            else
            {
                ThereNOTShard.Invoke();
            }

        }
    }

    public void CheckShardInInventory()
    {
        if (shardContainer.Count > 0)
        {
            IsShard = true;
        }
        else
        {
            IsShard = false;
        }
    }

    public void PayShard()
    {
        shardContainer.Withdraw(1);
    }
}
