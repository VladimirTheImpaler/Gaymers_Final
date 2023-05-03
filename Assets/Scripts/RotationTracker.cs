using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTracker : MonoBehaviour
{
    public Vector3 originRotationXYZ;
    public Vector3 rotationXYZ;

    // Start is called before the first frame update
    void Start()
    {
        originRotationXYZ= GetComponent<Rigidbody>().rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        rotationXYZ= GetComponent<Rigidbody>().rotation.eulerAngles;
    }
}
