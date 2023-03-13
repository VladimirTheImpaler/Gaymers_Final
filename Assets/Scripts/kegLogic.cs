using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kegLogic : MonoBehaviour
{

    public GameObject liquidDrop;

    int timer = 10;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void spawnBall()
    {

        timer -= 1;

        if (timer < 0)
        {

            timer = 10;
            //summon liquidBall
            GameObject newLiquid = Instantiate(liquidDrop, new Vector3(-0.5f, 3.65f, 0.85f), Quaternion.identity) as GameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
