using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardsScript : MonoBehaviour
{
    public GameObject BackGround;
    private SpriteRenderer BackgroundBound;
    private float DownBoarder, UpBoarder;
    //public float numbersofsprites;

    private float length;
    public float movingspeed;
    void Start()
    {
        
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        BackgroundBound = BackGround.GetComponent<SpriteRenderer>();
        DownBoarder = (float)(BackgroundBound.bounds.min.y);
        UpBoarder = (float)(BackgroundBound.bounds.max.y);
    }


    void FixedUpdate()
    {
        float temp = transform.position.y;
        transform.position = new Vector3(transform.position.x , transform.position.y + movingspeed, transform.position.z);

        if ((temp + length / 2) > UpBoarder)
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + length * numbersofsprites, transform.position.z);
            transform.position = new Vector3(transform.position.x, DownBoarder - length / 2, transform.position.z);
        }
    }
}
