using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourOnRotate : MonoBehaviour
{
    public float rotationX;
    public float rotationY;
    public float rotationZ;
    public bool pouring = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        rotationX = GetComponent<Rigidbody>.transform.rotation.x;
        rotationY = GetComponent<Rigidbody>.transform.rotation.y;
        rotationZ = GetComponent<Rigidbody>.transform.rotation.z;
        
        if (rotationX > Abs(90) || rotationZ > Abs(90)) {
            pouring = true;
        }
        else {
            pouring = false;
        }
        */
    }
}
