using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Testing
{
    [CreateAssetMenu(fileName = "Player's Item", menuName = "Testing/Player Container")]
    public class PlayersItem : ScriptableObject
    {
        public Container itemContainer;
    }
}
