using System;
using UnityEngine;

namespace Project.Testing
{
    [CreateAssetMenu(fileName = "Player's Item", menuName = "Testing/Player Container")]
    public class PlayersItem : ScriptableObject
    {
        private Container itemContainer;

        public event Action PlayerItemUpdated;

        public Container ItemContainer
        {
            get
            {
                return itemContainer;
            }

            set
            {
                itemContainer = value;

                if (PlayerItemUpdated != null)
                    PlayerItemUpdated();
            }
        }
    }
}
