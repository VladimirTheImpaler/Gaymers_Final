using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public GameObject cupPropertyList;

    public TextMeshProUGUI customerOrderText;
    public TextMeshProUGUI ingredientsListText;

    private string randomOrderableItem;

    public float speed = 5.0f;
    public float atBarPos = -5f;
    public float startingPos = -15f; //starting position
    public float leavingBarX = 2f;
    public float endingX = -15f;
    public float xStart = -10f;
    public float zStart = -5f;
    private int direction = 1; //positive to start

    private List<string> orderableItems = new List<string>() { "Purple Ice", "Liquid Apple", "Cube Juice" };
    private List<string> ingredients = new List<string>() { "Ice Cubes", "Keg Liquid", "Apple Juice" };

    public bool orderComplete;
    private bool arrivedAtBar;
    private bool displayedOrder;


    private void Start()
    {
        arrivedAtBar = false;
        displayedOrder = false;
        transform.position = new Vector3(2, 2.5f, -20);
        customerOrderText.enabled = false;
        ingredientsListText.enabled = false;
    }

    void Update()
    {
        // Moves the customer to the bar
        if (!arrivedAtBar && transform.position.z <= atBarPos)
        {
            float zNew = transform.position.z +
                        direction * speed * Time.deltaTime;

            transform.position = new Vector3(xStart, 2.5f, zNew);            
        }
            
        // Displays the customer's order once they arrive at the bar
        if ((int)transform.position.z == atBarPos)
        {
            if (!displayedOrder)
            {
                displayedOrder = true;
                arrivedAtBar = true;

                var randomOrderTextNumber = UnityEngine.Random.Range(0, 4);
                var randomOrderableItemsNumber = UnityEngine.Random.Range(0, orderableItems.Count);

                randomOrderableItem = orderableItems[randomOrderableItemsNumber];

                customerOrderText.text = $"{randomOrderTextNumber} {randomOrderableItem}";

                switch (randomOrderTextNumber)
                {
                    case 0:
                        customerOrderText.text = $"Hello! Could I please get a {randomOrderableItem}? Thank you!";
                        break;
                    case 1:
                        customerOrderText.text = $"Good afternoon, may I order a {randomOrderableItem}?";
                        break;
                    case 2:
                        customerOrderText.text = $"Greetings! I would like a {randomOrderableItem} please. They are my favorite!";
                        break;
                    case 3:
                        customerOrderText.text = $"Oh boy, I think that a {randomOrderableItem} sounds delicious. May I get one of those?";
                        break;
                }

                switch (randomOrderableItem)
                {
                    case "Purple Ice":
                        ingredientsListText.text = $"{randomOrderableItem}: \n 1. {ingredients[0]} \n 2. {ingredients[1]}";
                        break;
                    case "Liquid Apple":
                        ingredientsListText.text = $"{randomOrderableItem}: \n 1. {ingredients[1]} \n 2. {ingredients[2]}";
                        break;
                    case "Cube Juice":
                        ingredientsListText.text = $"{randomOrderableItem}: \n 1. {ingredients[2]} \n 2. {ingredients[0]}";
                        break;
                }

                customerOrderText.enabled = true;
                ingredientsListText.enabled = true;
            }            
        }

        if (!orderComplete)
        {
            var cupList = cupPropertyList.GetComponent<cupLogic>().itemList;
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
                    if (cupList.Contains("appleJuice") && cupList.Contains("iceCube"))
                    {
                        orderComplete = true;
                    }
                    break;
            }
        }

        if (orderComplete && arrivedAtBar)
        {
            float xNew = transform.position.x +
                    -1 * speed * Time.deltaTime;

            transform.position = new Vector3(xNew, 2.5f, zStart);

            if ((int)transform.position.x == endingX)
            {
                arrivedAtBar = false;
                orderComplete = false;
                displayedOrder = false;
                transform.position = new Vector3(2, 2.5f, -20);
                customerOrderText.enabled = false;
                ingredientsListText.enabled = false;
            }
        }
    }
}
