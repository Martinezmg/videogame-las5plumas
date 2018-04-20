using System;
using UnityEngine;

namespace Project.DialogueSystem
{
    [Serializable]
    public class Sentence
    {
        public string name;
        public Sprite sprite;

        [TextArea(3, 10)]
        public string[] lines;
    }
}
