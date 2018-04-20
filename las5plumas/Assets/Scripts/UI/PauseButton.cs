using UnityEngine;

namespace Project.UI
{
    public class PauseButton : MonoBehaviour
    {

        public void MoveTo()
        {
            GUIManager.instance.GoToInventory();
        }
    }
}