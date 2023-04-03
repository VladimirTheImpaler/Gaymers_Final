using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChalkboardLogic : MonoBehaviour
{
    public GameObject Customer;

    public TextMeshProUGUI orderAndIngredients;

    private bool displayedOrder;

    private List<string> orderableItems = new List<string>();
    private List<string> ingredients = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        orderableItems = Customer.GetComponent<CustomerController>().orderableItems;
        ingredients = Customer.GetComponent<CustomerController>().ingredients;
        displayedOrder = false;
        orderAndIngredients.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var randomOrderableItem = Customer.GetComponent<CustomerController>().randomOrderableItem;

        Debug.Log("Almost");

        if (randomOrderableItem != null && !displayedOrder)
        {
            displayedOrder = true;

            Debug.Log("There");

            switch (randomOrderableItem)
            {
                case "Purple Ice":
                    orderAndIngredients.text = $"\n<u>{randomOrderableItem}:</u> \n 1. {ingredients[0]} \n 2. {ingredients[1]}";
                    break;
                case "Liquid Apple":
                    orderAndIngredients.text = $"\n<u>{randomOrderableItem}:</u> \n 1. {ingredients[1]} \n 2. {ingredients[2]}";
                    break;
                case "Cube Juice":
                    orderAndIngredients.text = $"\n<u>{randomOrderableItem}:</u> \n 1. {ingredients[2]} \n 2. {ingredients[0]} \n 3. {ingredients[1]}";
                    break;
            }

            orderAndIngredients.enabled = true;

            /*GameObject addedChild = (GameObject)Instantiate(togglePrefab);
            addedChild.transform.SetParent(toggleContainer);

            Text text = addedChild.GetComponentInChildren<Text>();
            text.text = displayedTitle;*/
        }
    }
}
