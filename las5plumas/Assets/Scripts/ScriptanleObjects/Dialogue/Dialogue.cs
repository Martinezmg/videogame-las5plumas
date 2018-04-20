using System;
using UnityEngine;

namespace Project.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "ScriptableObjects/Dialogue")]
    public class Dialogue : ScriptableObject
    {        
        public Sentence[] sentences;
    }
}
