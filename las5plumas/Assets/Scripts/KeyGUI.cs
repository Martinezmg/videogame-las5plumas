using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI
{

    public class KeyGUI : MonoBehaviour
    {
        public Image keyImage;
        public Toggle keyToggle;

        private void OnEnable()
        {
            Check();
        }

        public void Check()
        {
            if (Inventory.Instance.inventoryDB.keys > 0)
            {
                keyImage.enabled = true;
                keyToggle.enabled = true;
            }
            else
            {
                keyImage.enabled = false;
                keyToggle.enabled = false;
            }
        }
    }
}
