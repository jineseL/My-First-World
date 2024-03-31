using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioLmao : MonoBehaviour
{
    public static AudioLmao instance2;
    private void Awake()
    {
        

        if (instance2 == null)
        {
            instance2 = this;
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
        if (SceneManager.GetActiveScene().name ==  "BossCutScene")
        {
            Destroy(gameObject);
        }
    }

}
