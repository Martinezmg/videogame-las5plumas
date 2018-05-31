using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DinamicConditioner : MonoBehaviour
{
    [SerializeField]
    private bool[] conditions;

    public UnityEvent OnTrue;

    public bool[] Conditions
    {
        get
        {
            return conditions;
        }

        set
        {
            conditions = value;
        }
    }

    public void TrueCondition(int index)
    {
        if (index >= conditions.Length)
        {
            return;
        }

        Conditions[index] = true;

        CheckConditions();
    }

    public void FalseCondition(int index)
    {
        if (index >= conditions.Length)
        {
            return;
        }

        Conditions[index] = false;

        CheckConditions();
    }

    private void CheckConditions()
    {
        foreach (bool condition in conditions)
        {
            if (!condition)
            {
                return;
            }
        }
        
        OnTrue.Invoke();
    }
}
