using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.UI.InGame
{
    public class UIProgress : MonoBehaviour
    {
        [SerializeField]
        private class Tuple
        {
            public Image i;
            public GameObject o;

            public Tuple(Image _i, GameObject _o)
            {
                i = _i;
                o = _o;
            }
        }

        public GameObject shard;
        public GameObject coin0;
        public GameObject coin1;
        public GameObject coin2;
        public GameObject coin3;
        public GameObject coin4;

        public Image ishard;
        public Image icoin0;
        public Image icoin1;
        public Image icoin2;
        public Image icoin3;
        public Image icoin4;

        public Sprite scoin;
        public Sprite sshard;

        private List<Tuple> pool;

        private void Awake()
        {
            pool = new List<Tuple> {
                new Tuple(icoin0, coin0),
                new Tuple(icoin1, coin1),
                new Tuple(icoin2, coin2),
                new Tuple(icoin3, coin3),
                new Tuple(icoin4, coin4),
            };


        }

        public void UpdateProgress()
        {
            //Si esto pasa se supone que ya el jugador encontro el objeto
            if (shard == null)
            {
                ishard.sprite = sshard;
            }

            foreach (var item in pool)
            {
                if (item.o == null)
                {
                    item.i.sprite = scoin;
                }
            }
        }

        private void Update()
        {
            UpdateProgress();
        }
    }
}
