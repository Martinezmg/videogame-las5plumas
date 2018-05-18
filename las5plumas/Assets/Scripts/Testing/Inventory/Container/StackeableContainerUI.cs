using System;
using UnityEngine;
using TouchScript.Gestures;
using TMPro;

namespace Project.Testing
{
    [RequireComponent(typeof(TapGesture)), RequireComponent(typeof(SpriteRenderer))]
    public class StackeableContainerUI : MonoBehaviour
    {
        public string itemName_;

        public StackeableContainer container_;
        public LevelProgress currentLvlAsset;

        private TapGesture tapGesture_;
        private SpriteRenderer render_;
        [SerializeField]
        public TextMeshPro text_;

        private void Awake()
        {
            tapGesture_ = GetComponent<TapGesture>();
            render_ = GetComponent<SpriteRenderer>();
            render_.color = currentLvlAsset.lvlColor;

            container_.Set();

            container_.OnAvailableChange += SetStatus;
            container_.OnCountChange += SetCount;

            SetStatus(container_.Available);
            SetCount(container_.Count);
        }

        private void OnEnable()
        {
            tapGesture_.Tapped += TakeItem;

            container_.OnAvailableChange += SetStatus;
            container_.OnCountChange += SetCount;

            SetStatus(container_.Available);
            SetCount(container_.Count);
        }

        private void OnDisable()
        {
            tapGesture_.Tapped -= TakeItem;

            container_.OnAvailableChange -= SetStatus;
            container_.OnCountChange -= SetCount;
        }

        private void OnDestroy()
        {
            tapGesture_.Tapped -= TakeItem;

            container_.OnAvailableChange -= SetStatus;
            container_.OnCountChange -= SetCount;
        }

        private void TakeItem(object sender, EventArgs e)
        {
            InventoryManager.Instance.selector.SelectItem(container_, transform);
        }

        private void SetStatus(bool available)
        {
            GetComponent<TapGesture>().enabled = available;
            //tapGesture_.enabled = available;
            render_.enabled = available;
            text_.enabled = available;
        }

        private void SetCount(int count)
        {
            if (count > 1)
                text_.text = "x" + count.ToString();
            else
                text_.text = "";
        }
    }
}
