using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.GameState
{
    [CreateAssetMenu(fileName = "New game file", menuName = "ScriptableObjects/GameFile")]
    public class GameFile : ScriptableObject
    {
        //public Player player;

        public Level[] levels;
    }
}
