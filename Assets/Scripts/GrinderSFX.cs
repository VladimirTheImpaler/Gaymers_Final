using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderSFX : MonoBehaviour
{
    public AudioSource grindingSFX;

    // Start is called before the first frame update
    void Start()
    {
        grindingSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CrankRotation>().crankThatHog > 4.0f) {
            grindingSFX.volume = 1;
        }
        else {
            grindingSFX.volume = 0;
        }
    }
}
