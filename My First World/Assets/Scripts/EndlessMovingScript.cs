using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMovingScript : MonoBehaviour
{
    public GameObject BackGround;
    private SpriteRenderer BackgroundBound;
    private float leftBorder, rightBoarder;
    public float numbersofsprites;

    private float length, startpos;
    public float movingspeed;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        BackgroundBound = BackGround.GetComponent<SpriteRenderer>();
        leftBorder = (float)(BackgroundBound.bounds.min.x);
        rightBoarder = (float)(BackgroundBound.bounds.max.x);
    }

    
    void FixedUpdate()
    {
        float temp = transform.position.x;
        transform.position = new Vector3(transform.position.x - movingspeed, transform.position.y, transform.position.z);

        if((temp+ length/2) < leftBorder)
        {
            transform.position = new Vector3(transform.position.x + length * numbersofsprites, transform.position.y, transform.position.z);
        }
    }
}
