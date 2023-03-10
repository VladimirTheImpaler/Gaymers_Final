using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempBarrelScript : MonoBehaviour
{

    int timer = 100

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer < 0)
        {

            timer = 100;
            //summon liquidBall
        }


    }
}
