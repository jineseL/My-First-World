using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FUWEIFHWUFH : MonoBehaviour
{
    public static FUWEIFHWUFH instance4;
    //public GameObject dialoguecanvas;
    
    private void Awake()
    {
        if (instance4 == null)
        {
            instance4 = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }

}
