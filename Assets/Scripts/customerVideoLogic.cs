using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerVideoLogic : MonoBehaviour
{

    public GameObject thisCustomerObject;
    public GameObject measureBox;
    public int thisVideoNumber;
    public int customerVideoNumber;
    public bool customerImposter;
    public bool isThisImposter;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        customerVideoNumber = measureBox.GetComponent<materialIndexTest>().customerVideoNumber;
        customerImposter = measureBox.GetComponent<materialIndexTest>().isImposterRound;



        /*if ((isThisImposter == customerImposter) && (customerVideoNumber == thisVideoNumber))
        {

            this.thisCustomerVideo.SetActive(true);
        }
        else
        {

            this.thisCustomerVideo.SetActive(false);
        }*/


    }
}
