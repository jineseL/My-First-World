using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f,0f,-10f);
    private float smoothtime = 0.25f;
    private Vector3 velocity= Vector3.zero;

    [SerializeField]
    private Transform target;

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 targetposition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothtime);
    }
}
