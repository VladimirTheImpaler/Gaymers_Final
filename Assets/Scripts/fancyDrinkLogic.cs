using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fancyDrinkLogic : MonoBehaviour
{

    public GameObject fancyDrink;
    public GameObject orderCompleteBox;
    public GameObject drinkMesh1;
    public GameObject cupColliderDisk;

    public GameObject lemonOnFancyDrink;
    public GameObject cherryOnFancyDrink;
    public GameObject strawOnFancyDrink;
    public GameObject umbrellaOnFancyDrink;
    public GameObject umbrellaBallOnFancyDrink;

    public bool moveToCustomer = false;
    public string order;
    public bool orderComplete;
    public bool isSuccessful;
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
        orderComplete = orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete;
        isSuccessful = orderCompleteBox.GetComponent<OrderCompleteLogic>().isSuccessful;

        if (((order == this.fancyDrinkName) && orderComplete) && isSuccessful)
        {
            moveToCustomer = true;
            //good sound here
        }
        else
        {
            moveToCustomer = false;
            //bad sound here
        }



        //if ((order == fancyDrinkName) && (orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete == true))
        if (moveToCustomer)
        {

            resetDropTimer = false;
            drinkMesh1.GetComponent<MeshRenderer>().enabled = true;

            if (cupColliderDisk.GetComponent<cupLogic>().itemList.Contains("cherry"))
            {

                cherryOnFancyDrink.GetComponent<MeshRenderer>().enabled = true;
            }
            if (cupColliderDisk.GetComponent<cupLogic>().itemList.Contains("lemon"))
            {

                lemonOnFancyDrink.GetComponent<MeshRenderer>().enabled = true;
            }
            if (cupColliderDisk.GetComponent<cupLogic>().itemList.Contains("straw"))
            {

                strawOnFancyDrink.GetComponent<MeshRenderer>().enabled = true;
            }
            if (cupColliderDisk.GetComponent<cupLogic>().itemList.Contains("umbrella"))
            {

                umbrellaOnFancyDrink.GetComponent<MeshRenderer>().enabled = true;
                umbrellaBallOnFancyDrink.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else if (!moveToCustomer)
        {

            resetDropTimer = true;
            drinkMesh1.GetComponent<MeshRenderer>().enabled = false;

            fancyDrink.transform.position = GetComponent<ObjectPosition>().originPosition;

            cherryOnFancyDrink.GetComponent<MeshRenderer>().enabled = false;

            lemonOnFancyDrink.GetComponent<MeshRenderer>().enabled = false;

            strawOnFancyDrink.GetComponent<MeshRenderer>().enabled = false;

            umbrellaOnFancyDrink.GetComponent<MeshRenderer>().enabled = false;
            umbrellaBallOnFancyDrink.GetComponent<MeshRenderer>().enabled = false;


        }




    }
}
