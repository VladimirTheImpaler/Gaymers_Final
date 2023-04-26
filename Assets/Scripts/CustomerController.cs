using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerController : MonoBehaviour
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
    public Material imposterWalk1;
    public Material imposterWalk2;
    public Material imposterWalk3;
    public Material imposterWalk4;

    public string randomOrderableItem;

    public float speed = 5.0f;
    public float atBarPos = -5f;
    public float startingPos = -15f;
    public float leavingBarX = 2f;
    public float endingX = -15f;
    public float imposterEndingX = -4f;
    public float endingZ = -12f;
    public float xStart = -10f;
    public float zStart = -5f;
    private int materialIndex = 0;
    public float delay = .2f;
    float timer;

    public List<string> orderableItems = new List<string>() { "Purple Ice", "Liquid Apple", "Cube Juice" };
    public List<string> ingredients = new List<string>() { "Ice Cubes", "Keg Liquid", "Apple Juice" };

    public bool orderComplete;
    public bool arrivedAtBar;
    public bool isImposterRound;
    private bool displayedOrder;
    private bool canMoveX;
    private bool isMovingZ;

    private void Start()
    {
        arrivedAtBar = false;
        displayedOrder = false;
        transform.position = new Vector3(2, 4f, -20);
        customerOrderText.enabled = false;
        speechBubble.SetActive(false);
    }

    void Update()
    {
        CustomerWalkAnimation();

        MoveToBar();

        DisplayOrder();

        CheckOrderComplete();

        MovementAfterComplete();
    }

    private void CustomerWalkAnimation()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            CustomerWalk();
            timer -= delay;
        }
    }

    public void CustomerWalk()
    {
        switch (materialIndex)
        {
            case 0:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk1 : walk1;
                break;
            case 1:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk2 : walk2;
                break;
            case 2:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk3 : walk3;
                break;
            case 3:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk4 : walk4;
                materialIndex = -1;
                break;
        }
        materialIndex++;
    }

    private void MoveToBar()
    {
        if (!arrivedAtBar && transform.position.z <= atBarPos)
        {
            float zNew = transform.position.z + speed * Time.deltaTime;

            transform.position = new Vector3(xStart, 4f, zNew);
        }
    }

    private void DisplayOrder()
    {
        if ((int)transform.position.z == atBarPos)
        {
            if (!displayedOrder)
            {
                displayedOrder = true;
                arrivedAtBar = true;

                var randomOrderTextNumber = UnityEngine.Random.Range(0, 4);
                var randomOrderableItemsNumber = UnityEngine.Random.Range(0, orderableItems.Count * 3);
                switch (randomOrderableItemsNumber)
                {
                    case 0:
                    case 1:
                    case 2:
                        randomOrderableItemsNumber = 0;
                        break;
                    case 3:
                    case 4:
                    case 5:
                        randomOrderableItemsNumber = 1;
                        break;
                    case 6:
                    case 7:
                    case 8:
                        randomOrderableItemsNumber = 2;
                        break;
                    case 9:
                    case 10:
                    case 11:
                        randomOrderableItemsNumber = 3;
                        break;
                }

                randomOrderableItem = orderableItems[randomOrderableItemsNumber];

                switch (randomOrderTextNumber)
                {
                    case 0:
                        customerOrderText.text = isImposterRound ? $"Argh! You need to make me a {randomOrderableItem}!" : $"Hello! Could I please get a {randomOrderableItem}? Thank you!";
                        break;
                    case 1:
                        customerOrderText.text = isImposterRound ? $"I'm starving! Make a {randomOrderableItem} for me." : $"Good afternoon, may I order a {randomOrderableItem}?";
                        break;
                    case 2:
                        customerOrderText.text = isImposterRound ? $"Make me a {randomOrderableItem} now. I don't have all day!" : $"Greetings! I would like a {randomOrderableItem} please. They are my favorite!";
                        break;
                    case 3:
                        customerOrderText.text = isImposterRound ? $"Hurry and make me a {randomOrderableItem}! I don't have all day." : $"Oh boy, I think that a {randomOrderableItem} sounds delicious. May I get one of those?";
                        break;
                }

                speechBubble.SetActive(true);
                customerOrderText.enabled = true;
            }
        }
    }

    private void CheckOrderComplete()
    {
        if (!orderComplete)
        {
            orderComplete = orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete;
        }
    }

    private void MovementAfterComplete()
    {
        if (isImposterRound)
        {
            canMoveX = transform.position.x - 1 >= imposterEndingX;
            isMovingZ = (int)transform.position.z != endingZ + 1;
            if (orderComplete && arrivedAtBar)
            {
                customerOrderText.enabled = false;
                speechBubble.SetActive(false);

                if (canMoveX)
                {
                    float xNew = transform.position.x + -1 * speed * Time.deltaTime;

                    transform.position = new Vector3(xNew, 4f, zStart);
                }
                else
                {
                    if (isMovingZ)
                    {
                        float zNew = transform.position.z +
                                        (-1) * speed * Time.deltaTime;

                        transform.position = new Vector3(imposterEndingX, 4f, zNew);
                    }
                    else
                    {
                        ResetForNextCustomer();
                    }
                }
            }
        }
        else
        {
            if (orderComplete && arrivedAtBar)
            {
                customerOrderText.enabled = false;
                speechBubble.SetActive(false);

                float xNew = transform.position.x +
                        -1 * speed * Time.deltaTime;

                transform.position = new Vector3(xNew, 4f, zStart);

                if ((int)transform.position.x == endingX)
                {
                    ResetForNextCustomer();
                }
            }
        }
    }

    private void ResetForNextCustomer()
    {
        arrivedAtBar = false;
        orderComplete = false;
        orderCompleteBox.GetComponent<OrderCompleteLogic>().orderComplete = false;
        displayedOrder = false;
        transform.position = new Vector3(2, 4f, -20);
        randomOrderableItem = string.Empty;
        cupPropertyList.GetComponent<cupLogic>().itemList.Clear();
        isImposterRound = 3 == UnityEngine.Random.Range(1, 6);
    }
}
