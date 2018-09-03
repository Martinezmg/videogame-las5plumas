using System;
using UnityEngine;

namespace Project.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "ScriptableObjects/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        public new string name;

        public Color highlightColor = Color.white;
        public string highlightCode;

        public Sentence[] sentences;
    }
}
