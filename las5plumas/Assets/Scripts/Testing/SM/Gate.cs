using UnityEngine;

namespace Project.Testing
{
    public class Gate : MonoBehaviour
    {
        //current state
        private GateState GateState_; //quizas deberia ser un SO??
        private GateState lockState_;

        public OpenState open_;
        public CloseState close_;
        public LockState lock_;
        public UnlockState unlock_;

        private void Start()
        {
            open_ = new OpenState();
            close_ = new CloseState(false);
            lock_ = new LockState(close_);
            unlock_ = new UnlockState(close_);

            GateState_ = close_;
            lockState_ = lock_;
        }

        //este metodo deberia ser el interact()
        public void Use(Item item)
        {
            GateState gateState = GateState_.Use(this, item);
            GateState lockState = GateState_.Use(this, item);

            if (gateState != null) //En el caso de que si haya cambiado
            {
                GateState_.Exit(this);
                GateState_ = gateState;
                GateState_.Enter(this);
            }

            if (lockState != null) //En el caso de que si haya cambiado
            {
                lockState_.Exit(this);
                lockState_ = lockState;
                lockState_.Enter(this);
            }
        }

        //class methods
        public void Open()
        {
            Debug.Log(name + " is Open.");
        }

        public void Close()
        {
            Debug.Log(name + " is Close.");
        }
    }
}
