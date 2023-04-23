using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCompleteLogic : MonoBehaviour
{
    public GameObject cupPropertyList;
    public GameObject customer;
    public GameObject cup;

    public bool orderComplete;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mainCup"))
        {
            var cupList = cupPropertyList.GetComponent<cupLogic>().itemList;
            var randomOrderableItem = customer.GetComponent<CustomerController>().randomOrderableItem;
            var isImposterRound = customer.GetComponent<CustomerController>().isImposterRound;
            if (!isImposterRound)
            {
                switch (randomOrderableItem)
                {
                    case "Purple Ice":
                        if (cupList.Contains("iceCube") && cupList.Contains("kegLiquid"))
                        {
                            orderComplete = true;
                        }
                        break;
                    case "Liquid Apple":
                        if (cupList.Contains("kegLiquid") && cupList.Contains("appleJuice"))
                        {
                            orderComplete = true;
                        }
                        break;
                    case "Cube Juice":
                        if (cupList.Contains("appleJuice") && cupList.Contains("iceCube") && cupList.Contains("kegLiquid"))
                        {
                            orderComplete = true;
                        }
                        break;
                }
            }
            else
            {
                switch (randomOrderableItem)
                {
                    case "Purple Ice":
                        if (cupList.Contains("iceCube") && cupList.Contains("kegLiquid") && cupList.Contains("poison"))
                        {
                            orderComplete = true;
                        }
                        break;
                    case "Liquid Apple":
                        if (cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("poison"))
                        {
                            orderComplete = true;
                        }
                        break;
                    case "Cube Juice":
                        if (cupList.Contains("appleJuice") && cupList.Contains("iceCube") && cupList.Contains("kegLiquid") && cupList.Contains("poison"))
                        {
                            orderComplete = true;
                        }
                        break;
                }
            }
            
        }
        
    }
}
