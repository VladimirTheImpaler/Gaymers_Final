using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChalkboardLogic : MonoBehaviour
{
    public GameObject Customer;

    public TextMeshProUGUI orderAndIngredients;
    public Canvas chalkboardCanvas;

    private bool displayedOrder;

    private List<string> ingredients = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        ingredients = Customer.GetComponent<CustomerController>().ingredients;
        displayedOrder = false;
        chalkboardCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var randomOrderableItem = Customer.GetComponent<CustomerController>().randomOrderableItem;

        if (randomOrderableItem != string.Empty && !displayedOrder)
        {
            displayedOrder = true;

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

            chalkboardCanvas.enabled = true;

            /*GameObject addedChild = (GameObject)Instantiate(togglePrefab);
            addedChild.transform.SetParent(toggleContainer);

            Text text = addedChild.GetComponentInChildren<Text>();
            text.text = displayedTitle;*/
        }
    }
}
