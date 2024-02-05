using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    private GameObject HandSlam;
    private SlamMoveScript ReferenceScript;
    // Start is called before the first frame update
    void Start()
    {
        HandSlam = GetComponentInParent<GameObject>();
        ReferenceScript = GetComponentInParent<SlamMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    private void inidcating()
    {

    }
}
