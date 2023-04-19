using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankRotation : MonoBehaviour
{
    public float crankThatHog;
    public bool juicerIsJuicing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crankThatHog = GetComponent<Rigidbody>().angularVelocity.magnitude;

        if (crankThatHog > 5.0f) {
            juicerIsJuicing = true;
        }
        else {
            juicerIsJuicing = false;
        }
    }
}
