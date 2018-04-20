using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Interactables
{
    using States = List<Action>;
    using Transitions = Dictionary<StateTransition, Action>;

    internal class StateTransition
    {
        readonly public Action CurrentState; //#0
        readonly ItemAction Command;      //#1

        public StateTransition(Action currentState, ItemAction command)
        {       
            CurrentState = currentState;
            Command = command;
        }

        public override int GetHashCode()
        {
            return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            StateTransition other = obj as StateTransition;
            return other != null && CurrentState == other.CurrentState && Command == other.Command;
        }
    }

    public class StateMachine
    {
        //private States states;
        private Transitions transitions;
        private Action currentState;
        private Action finalState;
        
        public Action CurrentState { get { return currentState; } }
        public Action FinalState { get { return finalState; } }
        public bool IsFinal { get { return currentState == finalState; } }

        public StateMachine(States states_, Action iniState_, Action finalState_)
        {
            currentState = iniState_;
            finalState = finalState_;

            //states = states_;
            transitions = new Transitions();
            
        }

        public void AddTransition(Action currentState, ItemAction cmd, Action nextState)
        {
            StateTransition ts = new StateTransition(currentState, cmd);

            //ensure unique transitions
            Debug.Assert(!transitions.ContainsKey(ts));
                
            transitions.Add(ts, nextState);            

        }

        private bool GetNext(ItemAction command, out Action nextState)
        {
            StateTransition tempTransition = new StateTransition(CurrentState, command);

            return transitions.TryGetValue(tempTransition, out nextState);
        }

        //Esto es lo que deberia estar dentro de Interact()
        public bool MoveNext(ItemAction command)
        {
            Action tempState;

            if (GetNext(command, out tempState))
            {
                currentState = tempState;
                return true;
            }

            return false;
        }


    }
}