using System;
using UnityEngine;

namespace Project.Interactables
{
    public class Actioner : MonoBehaviour
    {
        public event Action<Transform> action;
        public event Action<Transform> specialAction;

        public void TriggerAction(Transform t)
        {
            if (action != null)
                action(t);
        }
        public void TriggerSpecialAction(Transform t)
        {
            if (specialAction != null)
                specialAction(t);
        }
    }
}
