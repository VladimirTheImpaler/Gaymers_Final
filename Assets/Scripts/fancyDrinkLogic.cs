using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fancyDrinkLogic : MonoBehaviour
{

    public GameObject fancyDrink;
    public GameObject orderCompleteBox;
    public GameObject drinkMesh1;

    public bool moveToCustomer = false;
    public string order;
    public string fancyDrinkName;
    public bool resetDropTimer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        order = orderCompleteBox.GetComponent<OrderCompleteLogic>().customer.GetComponent<CustomerController>().randomOrderableItem;

        //if ((order == fancyDrinkName) && (orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete == true))
        if (moveToCustomer)
        {

            resetDropTimer = false;
            drinkMesh1.GetComponent<MeshRenderer>().enabled = true;
            
        }
        else
        {

            resetDropTimer = true;
            drinkMesh1.GetComponent<MeshRenderer>().enabled = false;

            fancyDrink.transform.position = GetComponent<ObjectPosition>().originPosition;
        }
        



    }
}
