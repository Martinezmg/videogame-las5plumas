using UnityEngine;

namespace Project.GUI
{
    public class PauseButton : MonoBehaviour
    {

        public void MoveTo()
        {
            GUIManager.instance.GoToInventory();
        }
    }
}