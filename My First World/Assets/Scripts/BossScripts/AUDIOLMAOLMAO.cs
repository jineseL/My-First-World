using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AUDIOLMAOLMAO : MonoBehaviour
{
    public static AUDIOLMAOLMAO instance3;
    //public GameObject dialoguecanvas;
    public BossScript bscript;
    private void Awake()
    {


        if (instance3 == null)
        {
            instance3 = this;
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
        
        if (bscript.bossdead == true)
        {
            Destroy(gameObject);
        }
        
    }

}
