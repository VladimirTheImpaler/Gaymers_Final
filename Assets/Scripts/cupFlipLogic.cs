using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupFlipLogic : MonoBehaviour
{

    public GameObject cupParent;
    public float cupRotationX;
    public float cupRotationY;
    public float cupRotationZ;

    public bool wasFacingDownX;
    public bool wasFacingUpX;
    public bool wasFacingDownZ;
    public bool wasFacingUpZ;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        cupRotationX = cupParent.GetComponent<RotationTracker>().rotationXYZ.x;
        cupRotationY = cupParent.GetComponent<RotationTracker>().rotationXYZ.y;
        cupRotationZ = cupParent.GetComponent<RotationTracker>().rotationXYZ.z;

        if (((0 < cupRotationX) && (cupRotationX < 30)) || ((320 < cupRotationX) && (cupRotationX < 360)))
        {
            wasFacingDownX = true;
        }
        else
        {
            wasFacingDownX = false;
        }

        if ((140 < cupRotationZ) && (cupRotationZ < 200))
        {
            wasFacingDownZ = true;
        }
        else
        {
            wasFacingDownZ = false;
        }


        if ((140 < cupRotationZ) && (cupRotationZ < 200))
        {
            wasFacingDownZ = true;
        }
        else
        {
            wasFacingDownZ = false;
        }

    }
}
