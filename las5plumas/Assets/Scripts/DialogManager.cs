using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        public TMP_Text sentenceText;
        public Image speakerImage;

        public event Action<Dialogue> DialogBegan;
        public event Action<Dialogue> DialogEnd;

        private Dialogue currentDialog;

        public Image nextDialog;
        public Image exitDialog;
        private bool finalSentense = false;

        private void Start()
        {
            sentences = new Queue<Sentence>();
            lines = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            currentDialog = dialogue;
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

            if (DialogBegan != null) DialogBegan.Invoke(currentDialog);


            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            exitDialog.enabled = false;
            nextDialog.enabled = false;

            if (sentences.Count == 0 && lines.Count == 0)
            {
                EndDialogue();
                return;
            }
            else if (sentences.Count == 0 && lines.Count == 1)
            {
                finalSentense = true;
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
            bool wholeWord = false;

            //foreach (char letter in sentence.ToCharArray())
            foreach (string word in sentence.Split(' '))
            {
                wholeWord = false;

                foreach (var letter in word.ToCharArray())
                {                    
                    if (letter == '<')
                    {
                        wholeWord = true;
                        break;
                    }

                    sentenceText.text += letter;

                    yield return null;
                }
                if (wholeWord)
                    sentenceText.text += word + " ";
                else
                    sentenceText.text += " ";
                
                yield return null;
            }

            if (finalSentense)
                exitDialog.enabled = true;
            else
                nextDialog.enabled = true;
        }

        void EndDialogue()
        {
            canvas.enabled = false;
            exitDialog.enabled = false;
            nextDialog.enabled = false;
            finalSentense = false;

            if (DialogEnd != null) DialogEnd.Invoke(currentDialog);

            //animator.SetBool("IsOpen", false);

            //enable player controller
        }
    }
}

