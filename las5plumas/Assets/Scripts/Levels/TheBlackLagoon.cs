using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Levels
{

    public class TheBlackLagoon : Singleton<TheBlackLagoon>
    {
        protected TheBlackLagoon() { }

        
        private bool gateDiscovered = false;
        private bool chestDiscovered = false;

        [Header("DB system")]
        public GameObject key;
        public GameObject coin0;
        public GameObject coin1;
        public GameObject coin2;
        public GameObject coin3;
        public GameObject coin4;
        public GameObject shard;

        public bool GateDiscovered
        {
            get
            {
                return gateDiscovered;
            }

            set
            {
                gateDiscovered = value;
            }
        }

        public bool ChestDiscovered
        {
            get
            {
                return chestDiscovered;
            }

            set
            {
                chestDiscovered = value;
            }
        }
    }
}
