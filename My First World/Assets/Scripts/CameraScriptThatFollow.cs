using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,0f,-10f);
    private float smoothtime = 0.25f;
    private Vector3 velocity= Vector3.zero;

    //bounding
    public GameObject BackGround;
    private SpriteRenderer BackgroundBound;
    private float leftBorder;
    private float TopBorder;
    private float BottomBorder;
    private float RightBorder;
    private Camera gamecamera;

    [SerializeField]
    private Transform target;

    private void Start()
    {
        

        //gamecamera = GetComponent<Camera>();
        gamecamera = GetComponentInChildren<Camera>();
        BackgroundBound = BackGround.GetComponent<SpriteRenderer>();
        
        float vertextent = gamecamera.orthographicSize;
        float horzextent = (float)(vertextent * gamecamera.aspect);

        leftBorder = (float)(horzextent + BackgroundBound.bounds.min.x);
        TopBorder = (float)(BackgroundBound.bounds.max.y - vertextent);
        BottomBorder = (float)(vertextent + BackgroundBound.bounds.min.y );
        RightBorder = (float)( BackgroundBound.bounds.max.x- horzextent);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
        
        /*if (leftBorder.position.x < BackgroundBound.min.x)
        {
            Vector3 targetposition = target.position + offset;
            targetposition = new Vector3(BackgroundBound.min.x+ (cameara.orthographicSize*2), transform.position.y, transform.position.z);    
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);
        }
        if (TopBorder.position.y > BackgroundBound.max.y)
        {
            Vector3 targetposition = target.position + offset;
            targetposition = new Vector3(transform.position.x, BackgroundBound.max.y - (cameara.orthographicSize * 2), transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);
        }*/
        /*if (leftBorder.position.x < BackgroundBound.min.x)
        {
            Vector3 targetposition = target.position + offset;
            targetposition = new Vector3(BackgroundBound.min.x + (cameara.orthographicSize * 2), transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);
        }
        if (leftBorder.position.x < BackgroundBound.min.x)
        {
            Vector3 targetposition = target.position + offset;
            targetposition = new Vector3(BackgroundBound.min.x + (cameara.orthographicSize * 2), transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);
        }*/
        
            Vector3 targetposition = target.position + offset;
        targetposition.x = Mathf.Clamp(targetposition.x, leftBorder, RightBorder);
        targetposition.y = Mathf.Clamp(targetposition.y, BottomBorder, TopBorder);

        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);

            
        
    }
}
