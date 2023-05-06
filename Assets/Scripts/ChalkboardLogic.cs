using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChalkboardLogic : MonoBehaviour
{
    public GameObject Customer;
    public GameObject orderCompleteBox;
    public GameObject cupPropertyList;
    public GameObject floorMat;
    public GameObject robot;

    public Toggle Ingredient1Toggle;
    public Toggle Ingredient2Toggle;
    public Toggle Ingredient3Toggle;
    public Toggle Ingredient4Toggle;
    public Toggle Ingredient5Toggle;

    private GameObject Ingredient1ToggleObject;
    private GameObject Ingredient2ToggleObject;
    private GameObject Ingredient3ToggleObject;
    private GameObject Ingredient4ToggleObject;
    private GameObject Ingredient5ToggleObject;

    public TextMeshProUGUI orderAndIngredients;
    public TextMeshProUGUI tipsText;
    public TextMeshProUGUI choresText;

    public Canvas chalkboardCanvas;

    public bool robotAtChalkboard;
    public bool canvasState;
    private bool orderComplete;
    public bool displayedOrder;

    private List<string> ingredients = new List<string>();

    void Start()
    {
        ingredients = Customer.GetComponent<CustomerController>().ingredients;

        Ingredient1ToggleObject = GameObject.FindWithTag("Ingredient1Toggle");
        Ingredient2ToggleObject = GameObject.FindWithTag("Ingredient2Toggle");
        Ingredient3ToggleObject = GameObject.FindWithTag("Ingredient3Toggle");
        Ingredient4ToggleObject = GameObject.FindWithTag("Ingredient4Toggle");
        Ingredient5ToggleObject = GameObject.FindWithTag("Ingredient5Toggle");

        Ingredient1ToggleObject.SetActive(false);
        Ingredient2ToggleObject.SetActive(false);
        Ingredient3ToggleObject.SetActive(false);
        Ingredient4ToggleObject.SetActive(false);
        Ingredient5ToggleObject.SetActive(false);

        displayedOrder = false;
        chalkboardCanvas.enabled = false;
        tipsText.text = $"\n<u>Tips</u>\n  $0.00";
        choresText.text = "\n<u>Chores</u>";
        Ingredient1Toggle.isOn = false;
        Ingredient2Toggle.isOn = false;
        Ingredient3Toggle.isOn = false;
        Ingredient4Toggle.isOn = false;
        Ingredient5Toggle.isOn = false;
    }

    void Update()
    {
        var randomOrderableItem = string.Empty;
        robotAtChalkboard = robot.GetComponent<RobotController>().atChalkboard;

        if (floorMat.GetComponent<juicerFreezeBlockLogic>().hasJuice)
        {
            choresText.text = "\n<u>Chores</u>\n* Sweep";
        } else
        {
            choresText.text = "\n<u>Chores</u>";
        }

        if (Customer.GetComponent<CustomerController>().arrivedAtBar)
        {
            randomOrderableItem = Customer.GetComponent<CustomerController>().randomOrderableItem;
        }

        if (randomOrderableItem != string.Empty && !displayedOrder)
        {
            switch (randomOrderableItem)
            {
                case "Purple Ice":
                    orderAndIngredients.text = $"\n<u>{randomOrderableItem}:</u> \n    {ingredients[0]} \n    {ingredients[1]}";
                    Ingredient1ToggleObject.SetActive(true);
                    Ingredient2ToggleObject.SetActive(true);
                    break;
                case "Liquid Apple":
                    orderAndIngredients.text = $"\n<u>{randomOrderableItem}:</u> \n    {ingredients[1]} \n    {ingredients[2]}";
                    Ingredient1ToggleObject.SetActive(true);
                    Ingredient2ToggleObject.SetActive(true);
                    break;
                case "Cube Juice":
                    orderAndIngredients.text = $"\n<u>{randomOrderableItem}:</u> \n    {ingredients[2]} \n    {ingredients[0]} \n    {ingredients[1]}";
                    Ingredient1ToggleObject.SetActive(true);
                    Ingredient2ToggleObject.SetActive(true);
                    Ingredient3ToggleObject.SetActive(true);
                    break;
            }
            displayedOrder = true;
        }

        if (robotAtChalkboard)
        {
            chalkboardCanvas.enabled = true;
            canvasState = chalkboardCanvas.enabled;
            robot.GetComponent<RobotController>().orderOnChalkboard = true;
            robot.GetComponent<RobotController>().canMoveBackFromChalkboard = true;
            robot.GetComponent<RobotController>().atChalkboard = true;
        }

        // Logic for ingredient checkboxes
        if (displayedOrder)
        {
            var cupIngredients = cupPropertyList.GetComponent<cupLogic>().itemList;
            switch (randomOrderableItem)
            {
                case "Purple Ice":
                    if (cupIngredients.Contains("iceCube"))
                    {
                        Ingredient1Toggle.isOn = true;
                    }
                    if (cupIngredients.Contains("kegLiquid"))
                    {
                        Ingredient2Toggle.isOn = true;
                    }
                    break;
                case "Liquid Apple":
                    if (cupIngredients.Contains("kegLiquid"))
                    {
                        Ingredient1Toggle.isOn = true;
                    }
                    if (cupIngredients.Contains("appleJuice"))
                    {
                        Ingredient2Toggle.isOn = true;
                    }
                    break;
                case "Cube Juice":
                    if (cupIngredients.Contains("appleJuice"))
                    {
                        Ingredient1Toggle.isOn = true;
                    }
                    if (cupIngredients.Contains("iceCube"))
                    {
                        Ingredient2Toggle.isOn = true;
                    }
                    if (cupIngredients.Contains("kegLiquid"))
                    {
                        Ingredient3Toggle.isOn = true;
                    }
                    break;
            }
        }

        if (!orderComplete)
        {
            orderComplete = Customer.GetComponent<CustomerController>().orderComplete;
        }

        if (orderComplete && displayedOrder)
        {
            displayedOrder = false;
            orderComplete = false;
            chalkboardCanvas.enabled = false;
            Ingredient1Toggle.isOn = false;
            Ingredient2Toggle.isOn = false;
            Ingredient3Toggle.isOn = false;
            Ingredient4Toggle.isOn = false;
            Ingredient5Toggle.isOn = false;
            Ingredient1ToggleObject.SetActive(false);
            Ingredient2ToggleObject.SetActive(false);
            Ingredient3ToggleObject.SetActive(false);
            Ingredient4ToggleObject.SetActive(false);
            Ingredient5ToggleObject.SetActive(false);
            robot.GetComponent<RobotController>().orderOnChalkboard = false;
        }
    }
}
