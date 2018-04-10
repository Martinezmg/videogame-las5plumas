using System;
using UnityEngine;

namespace Project
{
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

        public ItemUI(string name)
        {
            this.name = name;
        }

        public void UpdateObjectName()
        {
            if (sprite == null)
                return;

            sprite.name = name;            
        }
    }
}
