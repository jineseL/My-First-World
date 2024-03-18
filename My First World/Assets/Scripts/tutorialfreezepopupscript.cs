using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialfreezepopupscript : MonoBehaviour
{
    
    float timer;
    public float tutorialduration; //before press enter to continue pops up 
    bool activated = false;
    GameObject player;
    public int levelno;
    public GameObject toshow;
    public GameObject PopupImage2;
    public GameObject enter;


    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == true)
        {
            if(timer < tutorialduration)
            {
                timer += Time.unscaledDeltaTime;
            }
            else
            {
                enter.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Time.timeScale = 1;
                    player.GetComponent<PlayerMovement>().caninput = true;
                    FindObjectOfType<Canvas>().enabled = true;
                    enter.SetActive(false);
                    if (levelno == 1)
                     {
                       if (LogicManagerScript.rain == true)
                        {
                            toshow.SetActive(false);
                        }
                        else
                        { PopupImage2.SetActive(false); }
                     }
                    else { toshow.SetActive(false); }
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            switch (levelno)
            {
                case 1:
                    if (LogicManagerScript.RainspawnerEnable)
                    {
                        if (LogicManagerScript.rain == false)
                        {
                            LogicManagerScript.rain = true;
                            showpopup();
                        }
                    }
                    else {
                        if (LogicManagerScript.wind == false)
                        {
                            LogicManagerScript.wind = true;
                            showpopup();
                        }
                    }
                    break;
                case 2:
                    if (LogicManagerScript.doublejump == false)
                    {
                        LogicManagerScript.doublejump = true;
                        showpopup();
                    }
                    break;
                case 3:
                    if (LogicManagerScript.speed == false)
                    {
                        LogicManagerScript.speed = true;
                        showpopup();
                    }
                    break;
                case 4:
                    if (LogicManagerScript.ice == false)
                    {
                        LogicManagerScript.ice = true;
                        showpopup();
                    }
                    break;
                case 5:
                    if (LogicManagerScript.sand == false)
                    {
                        LogicManagerScript.sand = true;
                        showpopup();
                    }
                    break;
            }
            
        }
    }
    private void showpopup()
    {
        if (levelno == 1)
        {
            if (LogicManagerScript.rain == true)
            {
                toshow.SetActive(true);
            }
            else
            { PopupImage2.SetActive(true); }
        }
        else { toshow.SetActive(true); }
        Time.timeScale = 0;
        player.GetComponent<PlayerMovement>().caninput = false;
        FindObjectOfType<Canvas>().enabled = false;
        activated = true;
    }
}
