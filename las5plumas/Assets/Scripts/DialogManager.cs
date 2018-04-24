using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.DialogueSystem
{

    public class DialogManager : Singleton<DialogManager>
    {
        protected DialogManager() { }

        private Queue<Sentence> sentences;
        private Queue<string> lines;
        //private string speaker;

        public Canvas canvas;

        public Text speakerName;
        public Text sentenceText;
        public Image speakerImage;

        private void Start()
        {
            sentences = new Queue<Sentence>();
            lines = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            //disable player controls

            //animator.SetBool("IsOpen", true);

            //nameText.text = dialogue.name;

            canvas.enabled = true;

            sentences.Clear();
            lines.Clear();

            foreach (Sentence _sentence in dialogue.sentences)
            {
                sentences.Enqueue(_sentence);
            }

            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0 && lines.Count == 0)
            {
                EndDialogue();
                return;
            }

            if (lines.Count == 0)
            {
                Sentence s = sentences.Dequeue();
                //speaker = s.name.ToUpper();
                speakerName.text = s.name.ToUpper();
                speakerImage.sprite = s.sprite;

                foreach (string item in s.lines)
                {
                    lines.Enqueue(item);
                }
            }


            string sentence = lines.Dequeue();
            //sentenceText.text = lines.Dequeue();

            //Debug.Log(speaker + ": " + sentence);
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            //yield return null;
            sentenceText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                sentenceText.text += letter;
                yield return null;
            }
        }

        void EndDialogue()
        {
            canvas.enabled = false;

            //animator.SetBool("IsOpen", false);

            //enable player controller
        }
    }
}

