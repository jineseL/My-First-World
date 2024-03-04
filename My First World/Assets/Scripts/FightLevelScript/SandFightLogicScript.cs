using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandFightLogicScript : MonoBehaviour
{
    
    public GameObject[] platforms;
    
    public EnemySpawnerScript referenceenemyspawnerscript;
    
    public GameObject MiniBoss;
    public GameObject healthbar;

    private float breaktimer;
    public float breakduration;

    private GameObject[] Enemies;
    void Start()
    {
        
        breaktimer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (referenceenemyspawnerscript.completed == false)
        {
            
        }
        else if (enemycheck() == true)
        {
            if (breaktimer < breakduration)
            {
                breaktimer += Time.deltaTime;
            }
            else
            {
                
                healthbar.SetActive(true);
                MiniBoss.SetActive(true);

            }
        }
    }

    private bool enemycheck()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemies");
        for (int i = 0; i < Enemies.Length; i++)
        {
            if (Enemies[i] != null)
            {
                return false;
            }
        }
        return true;
    }
    
}
