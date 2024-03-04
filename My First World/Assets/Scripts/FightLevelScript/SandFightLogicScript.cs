using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandFightLogicScript : MonoBehaviour
{

    public float downspeed;
    /*public GameObject platforms1;
    public GameObject platforms2;
    public GameObject platforms3;
    public GameObject platforms4;
    public GameObject platforms5;
    public GameObject platforms6;
    public GameObject platforms7;
    public GameObject platforms8;
    public GameObject platforms9;*/
    public GameObject[] Godown;
    public GameObject GroundPlatform;


    public BirdSpawner referenceenemyspawnerscript;
    
    public GameObject MiniBoss;
    public GameObject healthbar;

    private float breaktimer;
    public float breakduration;

    private float destroytimer;
    public float timetodestroy;

    
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

            if(destroytimer< timetodestroy)
            {
                destroytimer += Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < Godown.Length; i++)
                {
                    Destroy(Godown[i]);
                }
            }
            if (breaktimer < breakduration)
            {
                breaktimer += Time.deltaTime;
                for(int i =0; i < Godown.Length; i++)
                {
                    godown(Godown[i]);
                }
                if(GroundPlatform.transform.position.y < -6.06f)
                {
                    GroundPlatform.transform.position += Vector3.up * Time.deltaTime * downspeed;
                }

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
    private void godown(GameObject platform)
    {
        platform.transform.position += Vector3.down *Time.deltaTime*downspeed;
    }
    
}
