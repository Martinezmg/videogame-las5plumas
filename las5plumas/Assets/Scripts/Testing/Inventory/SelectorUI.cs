using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Game.Player;

namespace Project.Testing
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SelectorUI : MonoBehaviour
    {
        private SpriteRenderer render;

        public PlayersItem playercontainer;

        private void Awake()
        {
            render = GetComponent<SpriteRenderer>();
        }

        public void SelectItem(Container c, Transform t)
        {
            render.enabled = true;
            transform.position = t.position;

            //entregar al personaje
            playercontainer.itemContainer = c;
        }

        private void Update()
        {
            if (playercontainer.itemContainer != null && !playercontainer.itemContainer.Available)
                render.enabled = false;
        }
    }
}
