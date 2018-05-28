using UnityEngine;
using UnityEngine.Events;

public class OnSceneStart : MonoBehaviour
{
    public UnityEvent OnStart;

	void Start ()
    {
        if (OnStart!=null)
        {
            OnStart.Invoke();
        }
	}
}
