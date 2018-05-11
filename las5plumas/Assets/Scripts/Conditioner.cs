using UnityEngine;
using UnityEngine.Events;

public class Conditioner : MonoBehaviour
{
    public UnityEvent OnConditionChange;

    public bool condition = false;
    public bool Condition { get { return condition; }
        set
        {            
            condition = value;

            if (OnConditionChange != null)
            {
                OnConditionChange.Invoke();
            }
        } }
}
