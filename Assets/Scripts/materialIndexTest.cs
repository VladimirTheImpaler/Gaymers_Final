using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialIndexTest : MonoBehaviour
{

    public GameObject Customer;
    public int customerVideoNumber;
    public bool isImposterRound;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        customerVideoNumber = Customer.GetComponent<CustomerController>().materialIndex;
        isImposterRound = Customer.GetComponent<CustomerController>().isImposterRound;
    }
}
