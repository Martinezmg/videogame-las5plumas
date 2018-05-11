using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing.ChestSM
{
    public class Chest : Interactable
    {
        ChestState ChestState_;

        [HideInInspector]
        public OpenState open_;
        [HideInInspector]
        public CloseState close_;

        public Interactable chestContent;

        public UnityEvent OnOpen;
        public UnityEvent Openend;

        private void Start()
        {
            open_ = new OpenState();
            close_ = new CloseState();

            ChestState_ = close_;
        }

        public override void Use(Item item)
        {
            ChestState chestState = ChestState_.Use(this, item);

            if (chestState != null) //En el caso de que si haya cambiado
            {
                ChestState_.Exit(this);
                ChestState_ = chestState;
                ChestState_.Enter(this);
            }
        }

        public void Open()
        {
            Debug.Log(name + " is Open.");
            //Invoke(OnOpen);

            if (chestContent != null)
                chestContent.Use(null);
            else
                Debug.LogWarning("There is not any interactable object attached to " + name);


        }

        public void Close()
        {
            Debug.Log(name + " is Close.");
        }

        private void Opened()
        {
            Invoke(Openend);
        }

        public void Invoke(UnityEvent e)
        {
            if (e != null)
            {
                e.Invoke();
            }
        }
    }
}
