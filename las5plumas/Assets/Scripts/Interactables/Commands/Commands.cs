using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Interactables
{
    [CreateAssetMenu(fileName = "Commands", menuName = "Interactable Commands")]
    public class Commands : ScriptableObject
    {
        public static  Commands instance;

        public List<string> commands = new List<string>();

        public Commands Instance {
            get {
                if (instance == null)
                    instance = new Commands();

                return instance;
                }
        }

        private Commands()
        {
                instance = this;
        }
    }
}
