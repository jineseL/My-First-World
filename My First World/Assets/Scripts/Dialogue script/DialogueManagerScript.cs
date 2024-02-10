using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    /*public Text Dialoguetext;
    private Queue<string> sentences; // first in first out data structure 

    public Animator animator;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue[] dialogue)
    {

        animator.SetBool("Isopen", true);
        sentences.Clear();
        for (int i = 0; i < dialogue.Length; i++)
        {
            foreach (string sentence in dialogue[i].sentences)
            {
                sentences.Enqueue(sentence);
            }
            
            Displaynextsentence();
        }
        *//*foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Displaynextsentence();*//*
    }
    public void Displaynextsentence()
    {
        //Debug.Log("HI");
        *//*if(dialogue.name != "hi")
        {
            Debug.Log("hi");
        }*//*
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Dialoguetext.text = sentence;
    }
    IEnumerator TypeSentence(string sentence)
    {
        Dialoguetext.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            Dialoguetext.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("Isopen", false);
        //Debug.Log("end of dialogue");
    }*/

    public Text Dialoguetext;
    private Queue<string> sentences; // first in first out data structure 
    private Queue<Dialogue> dialogues;
    public GameObject dialoguecanvas;
    public GameObject McDarken;
    public GameObject BossDarken;
    public GameObject McName;
    public GameObject BossName;
    public GameObject McLighten;
    public GameObject BossLighten;
    public GameObject option1;
    public GameObject option2;
    


    public Animator animator;
    void Start()
    {
        //dialoguecanvas = GameObject.Find("Dialogue Canvas");
        sentences = new Queue<string>();
        dialogues = new Queue<Dialogue>();
        
    }

    public void StartDialogue(Dialogue[] dialogue)
    {

        animator.SetBool("Isopen", true);
        //sentences.Clear();
        dialogues.Clear();
        //Debug.Log(dialogue.Length);
        for (int i = 0; i < dialogue.Length; i++)
        {
            foreach (string sentence in dialogue[i].sentences)
            {
                sentences.Enqueue(sentence);
            }

            //Displaynextsentence();
        }
        for (int i = 0; i < dialogue.Length; i++)
        {
            
                dialogues.Enqueue(dialogue[i]);
            //Displaynextsentence();
        }
        Displaynextsentence();
    }

    //for displaynextsentence function
    Dialogue dialogueinsentencetoshow;
    private float sentencecounter;
    public void Displaynextsentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (/*dialogueinsentencetoshow == null ||*/ sentencecounter == 0)
        {
            dialogueinsentencetoshow = dialogues.Dequeue();
            sentencecounter= dialogueinsentencetoshow.sentences.Length;
        }
        if (dialogueinsentencetoshow.options == true)
        {
            option1.SetActive(true);
            option2.SetActive(true);

        }
        else
        {
            if (dialogueinsentencetoshow.name == "Jing")
            {
                McLighten.GetComponent<Image>().enabled = true;
                McName.GetComponent<Image>().enabled = true;
                BossDarken.GetComponent<Image>().enabled = true;
                McDarken.GetComponent<Image>().enabled = false;
                BossLighten.GetComponent<Image>().enabled = false;
                BossName.GetComponent<Image>().enabled = false;

            }
            else
            {
                McLighten.GetComponent<Image>().enabled = false;
                McName.GetComponent<Image>().enabled = false;
                BossDarken.GetComponent<Image>().enabled = false;
                McDarken.GetComponent<Image>().enabled = true;
                BossLighten.GetComponent<Image>().enabled = true;
                BossName.GetComponent<Image>().enabled = true;
            }
            string sentence = sentences.Dequeue();
            sentencecounter -= 1;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        //Dialoguetext.text = sentence;
    }



    IEnumerator TypeSentence(string sentence)
    {
        Dialoguetext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Dialoguetext.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("Isopen", false);
        dialoguecanvas.SetActive(false);

        //Debug.Log("end of dialogue");
    }
    public void enablewind()
    {
        PlayerMovement.windEffect = true;
        disablebutton();
    }

    //options have to be enable after MC talking for it to make sense so options have to be true on the boss dialogue After a mc Dialogue
    public void disablebutton()
    {
        dialogueinsentencetoshow.options = false;
        Displaynextsentence();
        option1.SetActive(false);
        option2.SetActive(false);
    }
}
