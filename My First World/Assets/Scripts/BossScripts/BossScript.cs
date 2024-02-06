using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int BossHealth;
    private bool isinv;

    private float timer;
    public float invTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BossHealth == 0)
        {
            Destroy(gameObject);
        }
        if(isinv == true)
        {
            if (timer < invTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                isinv = false;
                timer = 0;
            }
        }

    }
    public void damage(int damagetaken)
    {
        if (isinv == false)
        {
            BossHealth -= damagetaken;
            isinv = true;
        }
    }
    
}