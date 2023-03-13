using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempBarrelScript : MonoBehaviour
{

    public GameObject liquidDrop;

    int timer = 1000;

    // Start is called before the first frame update
    void Start()
    {

        //liquidDrop.SetActive(true);
        //Instantiate(liquidDrop, new Vector3(0, 5, 0), Quaternion.identity);
    }

    private void spawnBall()
    {

        GameObject a = Instantiate(liquidDrop, new Vector3(0, 5, 0), Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1;

        

        if (timer < 0)
        {

            timer = 1000;
            //summon liquidBall
            spawnBall();
        }
        
    }
}
