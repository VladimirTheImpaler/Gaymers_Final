using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour
{
    public Vector3 originPosition;
    public Vector3 currentPosition;
    public float objectSpeed;


    // Start is called before the first frame update
    void Start()
    {
        originPosition = GetComponent<Rigidbody>().position;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = GetComponent<Rigidbody>().position;
        objectSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        
    }
}
