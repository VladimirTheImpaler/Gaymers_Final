using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourOnRotate : MonoBehaviour
{
    public bool isPouring;
    float pourCheckX;
    float pourCheckZ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pourCheckX = GetComponent<RotationTracker>().rotationXYZ.x;
        pourCheckZ = GetComponent<RotationTracker>().rotationXYZ.z;

        if (((90.0f < pourCheckX) && (pourCheckX < 270.0f)) || ((90.0f < pourCheckZ) && (pourCheckZ < 270.0f))) 
        {
            isPouring = true;
        }
        else
        {
            isPouring = false;
        }
    }
}
