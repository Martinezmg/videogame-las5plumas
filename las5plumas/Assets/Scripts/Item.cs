using System;
using UnityEngine;

namespace Project
{
    public enum ActionType
    {
        USE, OPEN, ATTACK, BURN, NONE
    }

    [Serializable]
    public class Item
    {
        public string name;
        public int quantity;

        public Item(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
    }

    [Serializable]
    public class Equipable : Item
    {
        public bool equiped = false;

        public Equipable(string name, int quantity) : base(name, quantity)
        {
        }
    }

    [Serializable]
    public class ItemUI
    {
        public string name;
        public SpriteRenderer sprite;
        public ActionType action;

        public ItemUI(string name)
        {
            this.name = name;
            action = ActionType.USE;
        }

        public void UpdateObjectName()
        {
            if (sprite == null)
                return;

            sprite.name = name;            
        }
    }
}
