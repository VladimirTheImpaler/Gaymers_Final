using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public GameObject orderCompleteBox;
    public GameObject cupPropertyList;
    public GameObject customer;
    public GameObject speechBubble;
    public GameObject robot;

    public TextMeshProUGUI customerOrderText;

    public Material customerWalk1;
    public Material customerWalk2;
    public Material customerWalk3;
    public Material customerWalk4;
    public Material customerWalk5;
    public Material customerWalk6;
    public Material customerWalk7;
    public Material imposterWalk1;
    public Material imposterWalk2;
    public Material imposterWalk3;
    public Material imposterWalk4;
    public Material imposterWalk5;
    public Material imposterWalk6;
    public Material imposterWalk7;

    public string randomOrderableItem;
    public string randomGarnish;
    public int lastItemOrdered = 100;
    public int randomOrderableItemsNumber;

    public float speed = 5.0f;
    public float atBarPos = -5f;
    public float startingPos = -15f;
    public float leavingBarX = 2f;
    public float endingX = -15f;
    public float imposterEndingX = -4f;
    public float endingZ = -12f;
    public float xStart = -10f;
    public float zStart = -5f;
    public int materialIndex;
    public float delay = .2f;
    float timer;
    float pauseAfterOrderComplete;

    private List<string> orderableItems = new List<string>() { "Apple Smoothie", "Keg Tonic", "Everything Smoothie", "Purple Ice", "Liquid Apple", "Cube Juice" };
    private List<string> ingredients = new List<string>() { "Ice Cubes", "Keg Liquid", "Apple Juice", "Shaved Ice", "Tonic" };
    private List<string> garnishes = new List<string>() { "Lemon", "Cherries", "Umbrella", "Straw"};

    public bool orderComplete;
    public bool arrivedAtBar;
    public bool isImposterRound;
    public bool displayedOrder;
    public bool doneWithTutorial;
    private bool canMoveX;
    private bool isMovingZ;
    private bool movedToPlayArea = false;

    private void Start()
    {
        arrivedAtBar = false;
        displayedOrder = false;
        customerOrderText.enabled = false;
        speechBubble.SetActive(false);
        this.gameObject.transform.position = new Vector3(100, 100, 100);
    }

    void Update()
    {
        doneWithTutorial = robot.GetComponent<RobotController>().inFinalPosition;
        if (doneWithTutorial)
        {           
            if (!movedToPlayArea)
            {
                transform.position = new Vector3(2, 4f, -20);
                movedToPlayArea = true;
            }

            //CustomerWalkAnimation();

            MoveToBar();

            DisplayOrder();

            CheckOrderComplete();

            if (orderComplete && pauseAfterOrderComplete >= 1.5f)
            {
                MovementAfterComplete();
            }
            else if (orderComplete)
            {
                pauseAfterOrderComplete += Time.deltaTime;
            }
        }
    }

    /*private void CustomerWalkAnimation()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            CustomerWalk();
            timer -= delay;
        }
    }*/

    public void CustomerWalk()
    {
        /*switch (materialIndex)
        {
            case 0:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk1 : customerWalk1;
                break;
            case 1:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk2 : customerWalk2;
                break;
            case 2:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk3 : customerWalk3;
                break;
            case 3:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk4 : customerWalk4;
                break;
            case 4:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk5 : customerWalk5;
                break;
            case 5:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk6 : customerWalk6;
                break;
            case 6:
                this.gameObject.GetComponent<MeshRenderer>().material = isImposterRound ? imposterWalk7 : customerWalk7;
                break;
        }*/
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
                randomGarnish = garnishes[UnityEngine.Random.Range(0, garnishes.Count)];

                do
                {
                    randomOrderableItemsNumber = UnityEngine.Random.Range(0, 6);
                    randomOrderableItem = orderableItems[randomOrderableItemsNumber];
                } while (randomOrderableItemsNumber == lastItemOrdered);

                lastItemOrdered = randomOrderableItemsNumber;

                switch (randomOrderTextNumber)
                {
                    case 0:
                        customerOrderText.text = string.Empty;
                        customerOrderText.text = isImposterRound ? $"Argh! You need to make me a {randomOrderableItem} with {randomGarnish}!" : $"Hello! Could I please get a {randomOrderableItem} with {randomGarnish}? Thank you!";
                        break;
                    case 1:
                        customerOrderText.text = string.Empty;
                        customerOrderText.text = isImposterRound ? $"I'm starving! Make a {randomOrderableItem} with {randomGarnish} for me." : $"Good afternoon, may I order a {randomOrderableItem} with {randomGarnish}?";
                        break;
                    case 2:
                        customerOrderText.text = string.Empty;
                        customerOrderText.text = isImposterRound ? $"Make me a {randomOrderableItem} with {randomGarnish} now. I don't have all day!" : $"Greetings! I would like a {randomOrderableItem} with {randomGarnish} please. They are my favorite!";
                        break;
                    case 3:
                        customerOrderText.text = string.Empty;
                        customerOrderText.text = isImposterRound ? $"Hurry and make me a {randomOrderableItem} with {randomGarnish}! I don't have all day." : $"Oh boy, I think that a {randomOrderableItem} with {randomGarnish} sounds delicious. May I get one of those?";
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
            isMovingZ = (int)transform.position.z <= endingZ + 1;
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
        orderCompleteBox.GetComponent<OrderCompleteLogic>().chargedTip = false;
        orderCompleteBox.GetComponent<OrderCompleteLogic>().isSuccessful = false;
        displayedOrder = false;
        transform.position = new Vector3(2, 4f, -20);
        randomOrderableItem = string.Empty;
        randomGarnish = string.Empty;
        cupPropertyList.GetComponent<cupLogic>().itemList.Clear();
        isImposterRound = 3 == UnityEngine.Random.Range(1, 4);
        robot.GetComponent<RobotController>().hasMovedForCurrentCustomer = false;
        materialIndex = UnityEngine.Random.Range(0, 7);
        pauseAfterOrderComplete = 0f;
    }
}
