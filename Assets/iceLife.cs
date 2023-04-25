using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceLife : MonoBehaviour
{

    public int iceLifeNum;

    // Start is called before the first frame update
    void Start()
    {


        this.iceLifeNum = 1000;
    }

    // Update is called once per frame
    void Update()
    {

        this.iceLifeNum -= 1;

        if (iceLifeNum < 0)
        {

            this.gameObject.SetActive(false);
        }
    }
}
