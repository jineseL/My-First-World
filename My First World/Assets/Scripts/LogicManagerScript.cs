using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;
    public GameObject rainspawner;
    public static bool RainspawnerEnable;
    public GameObject windeffect;
    


    private void Awake()
    {
        if (RainspawnerEnable == true)
        {
            rainspawner.SetActive(true);
        }
        else
        {
            rainspawner.SetActive(false);
        }
        if(PlayerMovement.windEffect == true)
        {
            windeffect.SetActive(true);
        }
        else
        {
            windeffect.SetActive(false);
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void minushealth()
    {
        if(heart5.enabled == true)
        {
            heart5.enabled = false;
        }
        else if (heart4.enabled == true)
        {
            heart4.enabled = false;
        }
        else if (heart3.enabled == true)
        {
            heart3.enabled = false;
        }
        else if (heart2.enabled == true)
        {
            heart2.enabled = false;
        }
        else if (heart1.enabled == true)
        {
            heart1.enabled = false;
        }
    }
}

