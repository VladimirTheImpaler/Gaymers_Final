using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public TextMeshProUGUI customerOrderText;
    public TextMeshProUGUI ingredientsListText;

    public GameObject cup;

    public float speed = 5.0f;
    public float atBarPos = -5f;
    public float startingPos = -15f; //starting position
    public float leavingBarX = 2f;
    public float endingX = 15f;
    public float xStart = -10f;
    public float zStart = -5f;
    private int direction = 1; //positive to start

    private List<string> orderText = new List<string>() { "Good morning, can I order a", "Good afternoon, can I order a", "Good evening, can I order a" };
    private List<string> orderableItems = new List<string>() { "Drink1", "Drink2", "Drink3" };
    private List<string> ingredients = new List<string>() { "Ice Cubes", "Keg Liquid", "Apple Juice" };

    public bool orderComplete;

    private void Start()
    {
        transform.position = new Vector3(2, 2.5f, -20);
        customerOrderText.enabled = false;
        ingredientsListText.enabled = false;
    }

    void Update()
    {
        bool arrivedAtBar = false;

        if (!arrivedAtBar)
        {
            if (transform.position.z == atBarPos)
            {
                arrivedAtBar = true;
            }

            float zNew = transform.position.z +
                        direction * speed * Time.deltaTime;

            transform.position = new Vector3(xStart, 2.5f, zNew);            
        }

        if ((int)transform.position.z == atBarPos)
        {
            var orderTextNumber = Random.Range(0, 2);
            var orderableItemsNumber = Random.Range(0, 2);

            var randomOrderText = orderText[orderTextNumber];
            var randomOrderableItem = orderableItems[orderableItemsNumber];

            customerOrderText.text = randomOrderText + " " + randomOrderableItem;

            if (randomOrderableItem == orderableItems[0])
            {
                ingredientsListText.text = $"{randomOrderableItem}: \n 1. {ingredients[0]} \n 2. {ingredients[1]}";
            } else if (randomOrderableItem == orderableItems[1])
            {
                ingredientsListText.text = $"{randomOrderableItem}: \n 1. {ingredients[1]} \n 2. {ingredients[2]}";
            }
            else if(randomOrderableItem == orderableItems[2])
            {
                ingredientsListText.text = $"{randomOrderableItem}: \n 1. {ingredients[2]} \n 2. {ingredients[0]}";
            }

            customerOrderText.enabled = true;
            ingredientsListText.enabled = true;
        }

        if (!orderComplete)
        {
            // Compare lists of ingredients to cup values
        }

        if (orderComplete)
        {
            if (transform.position.x >= endingX)
            {
                float xNew = transform.position.x +
                        -1 * speed * Time.deltaTime;

                transform.position = new Vector3(xNew, 2.5f, zStart);
            }

            if ((int)transform.position.x == endingX)
            {
                transform.position = new Vector3(2, 2.5f, -20);
                customerOrderText.enabled = false;
                ingredientsListText.enabled = false;
            }
        }
    }
}
