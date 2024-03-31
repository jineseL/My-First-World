using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossFightManager : MonoBehaviour
{
    public GameObject bosstiny,portal;
    public BossScript bscript;
    private float timer;
    private float bossappear=3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bscript.bossdead == true)
        {
            if (timer < bossappear)
            {
                timer += Time.deltaTime;
            }
            else
            {
                bosstiny.SetActive(true);
                portal.SetActive(true);
            }
        }
    }
}
