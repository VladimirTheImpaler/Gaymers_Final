using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSFX : MonoBehaviour
{
    public AudioClip pickup_SFX;
    public AudioClip collide_SFX;
    // public AudioClip fastCollide_SFX;   <-- Add if time, based on speed from 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // play pickup_SFX on pickup
        // play collide_SFX when colliding with something else
    }
}
