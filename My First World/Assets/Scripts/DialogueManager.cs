using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{ 
    //i honestly dk much of what im doing here
    public Text nametext;
    public Text DialogueText;
    public float textspeed;

    public Animator animator;
    private Queue<string> Names;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
        Names = new Queue<string>();
    }
    public void startDialogue(Dialogue dialogue)
    {
        animator.SetBool("Isopen", true);

        //nametext.text = dialogue.name;
        Names.Clear();
        sentences.Clear();
        foreach (string name in dialogue.names)
        {
            Names.Enqueue(name);
        }
        /*DisplayNextName();*/

        //sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //DisplayNextName();
        DisplayNextNameAndSentence();
    }
    /*public void DisplayNextName()
    {
        if (Names.Count == 0)
        {
            return;
        }
        string name = Names.Dequeue();
        //StopAllCoroutines();
        StartCoroutine(TypeName(name));
    }*/
    public void DisplayNextNameAndSentence()
    {
        if (Names.Count == 0)
        {
            EndDialogue();
            return;
        }
        string name = Names.Dequeue();
        if (sentences.Count == 0)
        {
            /*EndDialogue();*/
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeName(name));
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(textspeed);
        }
    }
    IEnumerator TypeName(string name)
    {
        nametext.text = "";
        foreach (char letter in name.ToCharArray())
        {
            nametext.text += letter;
            yield return new WaitForSeconds(textspeed);
        }
    }
    public void EndDialogue()
    {
        animator.SetBool("Isopen", false);
    }

    
}
