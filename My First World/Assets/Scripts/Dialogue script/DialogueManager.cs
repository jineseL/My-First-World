using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{ 
    
    public Text nametext;
    public Text DialogueText;
    public float textspeed;
    public int AmountofDialogue;

    public Animator animator;
    private Queue<string> Names;
    private Queue<string> sentences;

    public GameObject logicmanager;
    void Start()
    {
        sentences = new Queue<string>();
        Names = new Queue<string>();
    }

    // STARTING DIALOGUE
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

    //SHOWING THE NEXT SENTENCE
    public void DisplayNextNameAndSentence()
    {
        if (Names.Count == 0)
        {
            if (AmountofDialogue != 0)
            {
                AmountofDialogue -= 1;
                EndDialogueWithOptions();
                return;
            }
            else
            {
                EndDialogue();
                return;
            }
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

    //FOR LETTERS TO APPEAR ONE AT A TIME, EDIT TEXTSPEED TO CHANGE SPEED, SENTENCE IS FOR SENTENCE AND NAME IS FOR NAME
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

    //ENDING THE DIALOGUE FOR NOW ITS JUST TEXTBOX GOING DOWN
    public void EndDialogueWithOptions()
    {
        animator.SetBool("Isopen", false);
        logicmanager.GetComponent<LogicManagerforDialogue>().ActivateButtons();
    }
    public void EndDialogue()
    {
        animator.SetBool("Isopen", false);
        logicmanager.GetComponent<LogicManagerforDialogue>().ReturnToPlatform();
    }
    
}
