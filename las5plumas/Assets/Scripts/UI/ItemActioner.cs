using System;
using TouchScript.Gestures;
using UnityEngine;

namespace Project.Game
{
    [RequireComponent(typeof(TapGesture))]
    public class ItemActioner : MonoBehaviour
    {
        TapGesture tapGesture;

        private void Awake()
        {
            tapGesture = GetComponent<TapGesture>();
        }

        private void OnEnable()
        {
            tapGesture.Tapped += UseItem;
        }

        private void OnDisable()
        {
            tapGesture.Tapped -= UseItem;
        }

        private void UseItem(object sender, EventArgs e)
        {
            Inventory.inventory.UseItem(name);
        }
    }
}
