using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fancyDrinkLogic : MonoBehaviour
{

    public GameObject fancyDrink;
    public GameObject orderCompleteBox;
    public bool returnToBar = true;
    public string order;
    public string fancyDrinkName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        order = orderCompleteBox.GetComponent<OrderCompleteLogic>().customer.GetComponent<CustomerController>().randomOrderableItem;

        if ((order == fancyDrinkName) && (orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete == true))
        {

            fancyDrink.SetActive(true);
        }
        else if (returnToBar)
        {

            fancyDrink.transform.position = GetComponent<ObjectPosition>().originPosition;
            fancyDrink.SetActive(false);
        }



    }
}
