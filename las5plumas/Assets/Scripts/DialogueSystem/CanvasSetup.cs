using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Project.DialogueSystem
{
    public class CanvasSetup : MonoBehaviour
    {
        public Canvas canvas;
        public Text speakerName;
        public TextMeshProUGUI sentenceText;
        public Image speakerImage;
        public Image next;
        public Image exit;

        public void SetupCanvas()
        {
            DialogManager.Instance.canvas = canvas;
            DialogManager.Instance.speakerName = speakerName;
            DialogManager.Instance.sentenceText = sentenceText;
            DialogManager.Instance.speakerImage = speakerImage;
            DialogManager.Instance.nextDialog = next;
            DialogManager.Instance.exitDialog = exit;
        }
    }
}
