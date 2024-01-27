using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LogicManagerforDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    private bool clickonce =false;
    public GameObject dialogue;
    public GameObject dialogue2;
    public Button button1;
    public Button button2;
    private GameObject player;
    
    private void Start()
    {
        //FindObjectOfType<DialogueManager>().startDialogue(dialogue);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        player = FindObjectOfType<GameObject>(false);
    }
    private void Awake()
    {
        button1.onClick.AddListener(button1click);
        button2.onClick.AddListener(button2click);
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

    //avtivate buttons to be clickable, fade in fade out todo
    public void ActivateButtons()
    {
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);

        //for fading in buttons if want to do that in the future
        /*float alphanumber = 255f;
        while (alphanumber >= 225f)
        {
            alphanumber += Time.deltaTime;
        }
        button1.image.color = new Color(34f, 34f, 34f, alphanumber);*/

    }
    public void DeactivateButtons()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }

    //to edit what each button do, edit here
    public void button1click()
    {
        
        PlayerMovement.canDoubleJump = true;
        if (dialogue2)
        {
            dialogue2.GetComponent<DialogueTrigger>().TriggerDialogue();
            DeactivateButtons();
        }
        
    }
    public void button2click()
    {
        PlayerMovement.movementspeed += 5;
        if (dialogue2)
        {
            dialogue2.GetComponent<DialogueTrigger>().TriggerDialogue();
            DeactivateButtons();
        }
    }
    public void ReturnToPlatform()
    {
        SceneManager.LoadScene(("BaseLevel"));
    }
}
