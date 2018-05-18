using UnityEngine;

namespace Project.Levels
{

    public class TheBlackLagoon : Singleton<TheBlackLagoon>
    {
        protected TheBlackLagoon() { }

        public LevelProgress lvl1asset;
        
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

        private void Update()
        {
            if (coin0 == null)
            {
                lvl1asset.Coin1 = true;
            }
            if (coin1 == null)
            {
                lvl1asset.Coin2 = true;
            }
            if (coin2 == null)
            {
                lvl1asset.Coin3 = true;
            }
            if (coin3 == null)
            {
                lvl1asset.Coin4 = true;
            }
            if (coin4 == null)
            {
                lvl1asset.Coin5 = true;
            }
            if (shard == null)
            {
                lvl1asset.Shard = true;
            }
        }

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
