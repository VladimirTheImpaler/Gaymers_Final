using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBlockLogic : MonoBehaviour
{
    public GameObject iceCube;

    int timer = 50;
    bool useAble = true;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void spawnIce()
    {

        if (useAble)
        {

            timer = 50;
            //summon iceCube
            GameObject newIce = Instantiate(iceCube, new Vector3(-0.5f, 3.65f, 0.85f), Quaternion.identity) as GameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {

        timer -= 1;

        if (timer < 0)
        {
            useAble = true;
        }
        else
        {
            useAble = false;
        }
    }
}
