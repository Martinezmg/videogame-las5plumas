﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Project.DialogueSystem
{

    public class DialogManager : MonoBehaviour
    {
        public static DialogManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

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

        private bool escape = false;
        private Coroutine currentDisplay;

        public bool Escape
        {
            get
            {
                return escape;
            }

            set
            {
                escape = value;
            }
        }

        private void Start()
        {
            sentences = new Queue<Sentence>();
            lines = new Queue<string>();
        }

        public void Next()
        {
            if (escape)
            {
                DisplayNextSentence();
            }
            else
            {
                escape = true;
            }
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
            /*if (!exitDialog.enabled && !nextDialog.enabled)
            {
                return;
            }*/

            exitDialog.enabled = false;
            nextDialog.enabled = false;
            escape = false;

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
            escape = false;
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            //yield return null;
            sentenceText.text = "";

            bool isHighlight = false;

            //foreach (char letter in sentence.ToCharArray())
            foreach (string word in sentence.Split(' '))
            {                
                isHighlight = (word[0] == '<');
                
                foreach(char letter in word)
                {
                    if (letter == '<')
                        continue;

                    sentenceText.text += (!isHighlight) ?
                        letter + "" :
                        "<color=#" + currentDialog.highlightCode + ">" + letter + "</color>";
                    
                    if (!escape)
                        yield return null;
                }

                sentenceText.text += " ";

                if (!escape)
                    yield return null;
            }

            if (finalSentense)
                exitDialog.enabled = true;
            else
                nextDialog.enabled = true;

            escape = true;
        }

        public void EndDialogue()
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

