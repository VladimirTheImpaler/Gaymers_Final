using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ImposterController : MonoBehaviour
{
    public GameObject orderCompleteBox;
    public GameObject cupPropertyList;
    public GameObject customer;
    public GameObject speechBubble;

    public TextMeshProUGUI customerOrderText;

    public Material walk1;
    public Material walk2;
    public Material walk3;
    public Material walk4;

    public string randomOrderableItem;

    public float speed = 5.0f;
    public float atBarPos = -5f;
    public float startingPos = -15f;
    public float leavingBarX = 2f;
    public float endingX = -15f;
    public float endingZ = -12f;
    public float xStart = -10f;
    public float zStart = -5f;
    private int direction = 1;
    private int materialIndex = 0;
    public float delay = .2f;
    float timer;

    public List<string> orderableItems = new List<string>() { "Purple Ice", "Liquid Apple", "Cube Juice" };
    public List<string> ingredients = new List<string>() { "Ice Cubes", "Keg Liquid", "Apple Juice" };

    public bool orderComplete;
    public bool arrivedAtBar;
    public bool canSpawn;
    private bool displayedOrder;

    private void Start()
    {
        arrivedAtBar = false;
        displayedOrder = false;
        transform.position = new Vector3(2, 4f, -20);
        customerOrderText.enabled = false;
        speechBubble.SetActive(false);
        // this.gameObject.SetActive(false);
    }

    void Update()
    {
        canSpawn = true; // customer.GetComponent<CustomerController>().spawnImposterNext;

        if (canSpawn)
        {
            this.gameObject.SetActive(true);

            timer += Time.deltaTime;
            if (timer > delay)
            {
                CustomerWalk();
                timer -= delay;
            }

            // Moves the customer to the bar
            if (!arrivedAtBar && transform.position.z <= atBarPos)
            {
                float zNew = transform.position.z +
                            direction * speed * Time.deltaTime;

                transform.position = new Vector3(xStart, 4f, zNew);
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

                    switch (randomOrderTextNumber)
                    {
                        case 0:
                            customerOrderText.text = $"Argh! You need to make me a {randomOrderableItem}!";
                            break;
                        case 1:
                            customerOrderText.text = $"I'm starving! Make a {randomOrderableItem} for me.";
                            break;
                        case 2:
                            customerOrderText.text = $"Make me a {randomOrderableItem} now. I don't have all day!";
                            break;
                        case 3:
                            customerOrderText.text = $"Hurry and make me a {randomOrderableItem}! I don't have all day.";
                            break;
                    }

                    speechBubble.SetActive(true);
                    customerOrderText.enabled = true;
                    //ingredientsListText.enabled = true;
                }
            }

            if (!orderComplete)
            {
                orderComplete = orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete;
            }

            if (orderComplete && arrivedAtBar)
            {
                customerOrderText.enabled = false;
                speechBubble.SetActive(false);

                float xNew = transform.position.x +
                        -1 * speed * Time.deltaTime;

                transform.position = new Vector3(xNew, 4f, zStart);

                if ((int)transform.position.x == endingX)
                {
                    if ((int)transform.position.z != endingZ + 1)
                    {
                        float zNew = transform.position.z +
                                        (-1 * direction) * speed * Time.deltaTime;

                        transform.position = new Vector3(endingX, 4f, zNew);
                    }
                }

                if ((int)transform.position.z == endingZ)
                {
                    arrivedAtBar = false;
                    orderComplete = false;
                    orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete = false;
                    displayedOrder = false;
                    transform.position = new Vector3(2, 4f, -20);
                    randomOrderableItem = string.Empty;
                    cupPropertyList.GetComponent<cupLogic>().itemList.Clear();
                }
            }
        }        
    }

    public void CustomerWalk()
    {
        switch (materialIndex)
        {
            case 0:
                this.gameObject.GetComponent<MeshRenderer>().material = walk1;
                break;
            case 1:
                this.gameObject.GetComponent<MeshRenderer>().material = walk2;
                break;
            case 2:
                this.gameObject.GetComponent<MeshRenderer>().material = walk3;
                break;
            case 3:
                this.gameObject.GetComponent<MeshRenderer>().material = walk4;
                materialIndex = -1;
                break;
        }
        materialIndex++;
    }
}
