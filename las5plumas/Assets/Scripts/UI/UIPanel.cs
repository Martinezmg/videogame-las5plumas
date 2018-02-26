using UnityEngine;

namespace Project.Game.UI
{
    public class UIPanel : MonoBehaviour
    {
        public UIControls mainControls;

        public GameObject panelLeft, panelRigth;

        private void Awake()
        {
            if(gameObject.activeSelf != false)
            {
                mainControls.UIUpdate -= UIUpdate;
                mainControls.UIUpdate += UIUpdate;
            }
        }

        private void UIUpdate(Swipe s)
        {
            switch (s)
            {
                case Swipe.left:
                    if (panelLeft != null)
                    {
                        gameObject.SetActive(false);
                        panelLeft.SetActive(true);
                    }
                    break;
                case Swipe.rigth:
                    if (panelRigth != null)
                    {
                        gameObject.SetActive(false);
                        panelRigth.SetActive(true);
                    }
                    break;
                case Swipe.up:
                    break;
                case Swipe.down:
                    transform.parent.gameObject.SetActive(false);
                    break;
                case Swipe.none:
                    break;
                default:
                    break;
            }

        }

        private void OnEnable()
        {
            mainControls.UIUpdate -= UIUpdate;
            mainControls.UIUpdate += UIUpdate;
        }

        private void OnDisable()
        {
            mainControls.UIUpdate -= UIUpdate;
        }
    }
}
