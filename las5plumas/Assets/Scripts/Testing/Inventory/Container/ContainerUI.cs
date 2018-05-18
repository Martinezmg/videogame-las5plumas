using System;
using UnityEngine;
using UnityEngine.Events;
using TouchScript.Gestures;

namespace Project.Testing
{
    [RequireComponent(typeof(TapGesture)), RequireComponent(typeof(SpriteRenderer))]
    public class ContainerUI : MonoBehaviour
    {
        public string itemName_;

        public Container container_;
        public LevelProgress currentLvl;

        private TapGesture tapGesture_;
        private SpriteRenderer render_;

        private void Awake()
        {
            //container_ = InventoryManager.Instance.inventory.GetContainer(itemName_);

            tapGesture_ = GetComponent<TapGesture>();
            render_ = GetComponent<SpriteRenderer>();

            container_.Set();

            tapGesture_.enabled = container_.Available;
            render_.enabled = container_.Available;
            render_.color = currentLvl.lvlColor;
            //SetStatus(container_.Available);
        }

        private void OnEnable()
        {
            tapGesture_.Tapped += TakeItem;
            //container_.OnAvailableChange += SetStatus;

            //SetStatus(container_.Available);
        }

        private void OnDisable()
        {
            tapGesture_.Tapped -= TakeItem;
            //container_.OnAvailableChange -= SetStatus;
        }

        private void OnDestroy()
        {
            tapGesture_.Tapped -= TakeItem;
        }

        private void TakeItem(object sender, EventArgs e)
        {
            InventoryManager.Instance.selector.SelectItem(container_, transform);
        }
    }
}
