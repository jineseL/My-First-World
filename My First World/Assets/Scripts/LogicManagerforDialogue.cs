using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManagerforDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    private bool clickonce =false;
    public GameObject dialogue;
    private void Start()
    {
        //FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        if (clickonce == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                clickonce = true;
                dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();

            }
        }
    }
}
