using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public int BossHealth;
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

    }
    public void damage(int damagetaken)
    {
        BossHealth -= damagetaken;
    }
    
}
