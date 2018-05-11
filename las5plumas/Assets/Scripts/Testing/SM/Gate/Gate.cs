using UnityEngine;
using UnityEngine.Events;

namespace Project.Testing
{
    public class Gate : Interactable
    {
        //current state
        private GateState GateState_; //quizas deberia ser un SO??
        private GateState LockState_;

        public OpenState open_;
        public CloseState close_;
        public LockState lock_;
        public UnlockState unlock_;

        public UnityEvent OnTouch;
        public UnityEvent OnOpen;
        public UnityEvent Opened;

        private void Start()
        {
            open_ = new OpenState(null,true, false);
            close_ = new CloseState(null, false, true);
            lock_ = new LockState(close_, true, true);
            unlock_ = new UnlockState(close_, true, false);

            GateState_ = close_;
            LockState_ = lock_;
        }

        public override void Touch()
        {
            base.Touch();

            Invoke(OnTouch);
        }

        //este metodo deberia ser el interact()
        public override void Use(Item item)
        {
            GateState lockState = LockState_.Use(this, item);
            GateState gateState = GateState_.Use(this, item);

            if (lockState != null) //En el caso de que si haya cambiado
            {
                LockState_.Exit(this);
                LockState_ = lockState;
                LockState_.Enter(this);
            }

            if (gateState != null) //En el caso de que si haya cambiado
            {
                GateState_.Exit(this);
                GateState_ = gateState;
                GateState_.Enter(this);
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

        public void AnimationCompleted()
        {
            Invoke(Opened);
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
