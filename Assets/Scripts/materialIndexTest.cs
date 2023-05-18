using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialIndexTest : MonoBehaviour
{

    public GameObject Customer;
    public int customerVideoNumber;
    public bool isImposterRound;

    public GameObject customer1;
    public GameObject customer2;
    public GameObject customer3;
    public GameObject customer4;
    public GameObject customer5;
    public GameObject customer6;
    public GameObject customer7;

    public GameObject imposter1;
    public GameObject imposter2;   
    public GameObject imposter3;
    public GameObject imposter4;
    public GameObject imposter5;
    public GameObject imposter6;
    public GameObject imposter7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        customerVideoNumber = Customer.GetComponent<CustomerController>().materialIndex;
        isImposterRound = Customer.GetComponent<CustomerController>().isImposterRound;

        if (!isImposterRound)
        {

            imposter1.SetActive(false);
            imposter2.SetActive(false);
            imposter3.SetActive(false);
            imposter4.SetActive(false);
            imposter5.SetActive(false);
            imposter6.SetActive(false);
            imposter7.SetActive(false);

            switch (customerVideoNumber)
            {
                case 0:
                    customer1.SetActive(true);
                    customer2.SetActive(false);
                    customer3.SetActive(false);
                    customer4.SetActive(false);
                    customer5.SetActive(false);
                    customer6.SetActive(false);
                    customer7.SetActive(false);
                    break;
                case 1:
                    customer1.SetActive(true);
                    customer2.SetActive(false);
                    customer3.SetActive(false);
                    customer4.SetActive(false);
                    customer5.SetActive(false);
                    customer6.SetActive(false);
                    customer7.SetActive(false);
                    break;
                case 2:
                    customer1.SetActive(false);
                    customer2.SetActive(true);
                    customer3.SetActive(false);
                    customer4.SetActive(false);
                    customer5.SetActive(false);
                    customer6.SetActive(false);
                    customer7.SetActive(false);
                    break;
                case 3:
                    customer1.SetActive(false);
                    customer2.SetActive(false);
                    customer3.SetActive(true);
                    customer4.SetActive(false);
                    customer5.SetActive(false);
                    customer6.SetActive(false);
                    customer7.SetActive(false);
                    break;
                case 4:
                    customer1.SetActive(false);
                    customer2.SetActive(false);
                    customer3.SetActive(false);
                    customer4.SetActive(true);
                    customer5.SetActive(false);
                    customer6.SetActive(false);
                    customer7.SetActive(false);
                    break;
                case 5:
                    customer1.SetActive(false);
                    customer2.SetActive(false);
                    customer3.SetActive(false);
                    customer4.SetActive(false);
                    customer5.SetActive(true);
                    customer6.SetActive(false);
                    customer7.SetActive(false);
                    break;
                case 6:
                    customer1.SetActive(false);
                    customer2.SetActive(false);
                    customer3.SetActive(false);
                    customer4.SetActive(false);
                    customer5.SetActive(false);
                    customer6.SetActive(true);
                    customer7.SetActive(false);
                    break;
                case 7:
                    customer1.SetActive(false);
                    customer2.SetActive(false);
                    customer3.SetActive(false);
                    customer4.SetActive(false);
                    customer5.SetActive(false);
                    customer6.SetActive(false);
                    customer7.SetActive(true);
                    break;
            }

        } else if (isImposterRound)
        {

            customer1.SetActive(false);
            customer2.SetActive(false);
            customer3.SetActive(false);
            customer4.SetActive(false);
            customer5.SetActive(false);
            customer6.SetActive(false);
            customer7.SetActive(false);

            switch (customerVideoNumber)
            {
                case 0:
                    imposter1.SetActive(true);
                    imposter2.SetActive(false);
                    imposter3.SetActive(false);
                    imposter4.SetActive(false);
                    imposter5.SetActive(false);
                    imposter6.SetActive(false);
                    imposter7.SetActive(false);
                    break;
                case 1:
                    imposter1.SetActive(true);
                    imposter2.SetActive(false);
                    imposter3.SetActive(false);
                    imposter4.SetActive(false);
                    imposter5.SetActive(false);
                    imposter6.SetActive(false);
                    imposter7.SetActive(false);
                    break;
                case 2:
                    imposter1.SetActive(false);
                    imposter2.SetActive(true);
                    imposter3.SetActive(false);
                    imposter4.SetActive(false);
                    imposter5.SetActive(false);
                    imposter6.SetActive(false);
                    imposter7.SetActive(false);
                    break;
                case 3:
                    imposter1.SetActive(false);
                    imposter2.SetActive(false);
                    imposter3.SetActive(true);
                    imposter4.SetActive(false);
                    imposter5.SetActive(false);
                    imposter6.SetActive(false);
                    imposter7.SetActive(false);
                    break;
                case 4:
                    imposter1.SetActive(false);
                    imposter2.SetActive(false);
                    imposter3.SetActive(false);
                    imposter4.SetActive(true);
                    imposter5.SetActive(false);
                    imposter6.SetActive(false);
                    imposter7.SetActive(false);
                    break;
                case 5:
                    imposter1.SetActive(false);
                    imposter2.SetActive(false);
                    imposter3.SetActive(false);
                    imposter4.SetActive(false);
                    imposter5.SetActive(true);
                    imposter6.SetActive(false);
                    imposter7.SetActive(false);
                    break;
                case 6:
                    imposter1.SetActive(false);
                    imposter2.SetActive(false);
                    imposter3.SetActive(false);
                    imposter4.SetActive(false);
                    imposter5.SetActive(false);
                    imposter6.SetActive(true);
                    imposter7.SetActive(false);
                    break;
                case 7:
                    imposter1.SetActive(false);
                    imposter2.SetActive(false);
                    imposter3.SetActive(false);
                    imposter4.SetActive(false);
                    imposter5.SetActive(false);
                    imposter6.SetActive(false);
                    imposter7.SetActive(true);
                    break;
            }

        }

    }


}
