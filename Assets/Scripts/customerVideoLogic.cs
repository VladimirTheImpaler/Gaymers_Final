using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerVideoLogic : MonoBehaviour
{

    public GameObject thisCustomerVideo;
    public GameObject Customer;
    public int thisVideoNumber;
    private int customerVideoNumber;
    public bool customerImposter;
    public bool isThisImposter;
    
    public int visiableInt;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        customerVideoNumber = Customer.GetComponent<CustomerController>().materialIndex;
        customerImposter = Customer.GetComponent<CustomerController>().isImposterRound;

        visiableInt = customerVideoNumber;

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
