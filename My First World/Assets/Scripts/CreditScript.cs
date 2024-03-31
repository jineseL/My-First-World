using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            reset();
            
        }
    }

    public void reset()
    {
        LogicManagerScript.wind = false;
        LogicManagerScript.rain = false;
        LogicManagerScript.doublejump = false;
        LogicManagerScript.speed = false;
        LogicManagerScript.ice = false;
        LogicManagerScript.sand = false;
        LogicManagerScript.RainspawnerEnable = false;
        PlayerMovement.canDoubleJump = false;
        PlayerMovement.windEffect = false;
        PlayerMovement.movementspeed = 5f;
        SceneManager.LoadScene("MainMenu");
    }
}
