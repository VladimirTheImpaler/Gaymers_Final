using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderCompleteLogic : MonoBehaviour
{
    public GameObject cupPropertyList;
    public GameObject customer;
    public GameObject cup;

    public GameObject orderCompleteBox;
    public GameObject smokeEffect;

    public TextMeshProUGUI tipsText;

    public float tipsTotal = 0.00f;

    public bool orderComplete;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mainCup"))
        {
            var cupList = cupPropertyList.GetComponent<cupLogic>().itemList;
            var randomOrderableItem = customer.GetComponent<CustomerController>().randomOrderableItem;
            var isImposterRound = customer.GetComponent<CustomerController>().isImposterRound;
            var garnish = customer.GetComponent<CustomerController>().randomGarnish;
            bool isSuccessful = false;
            if (!isImposterRound)
            {
                switch (randomOrderableItem)
                {
                    case "Purple Ice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains(garnish.ToLower());
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully(); 
                        isSuccessful = false;
                        break;
                    case "Liquid Apple":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower());
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Cube Juice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains(garnish.ToLower());
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Apple Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains(garnish.ToLower());
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Keg Tonic":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower());
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Everything Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower());
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                }
            }
            else
            {
                switch (randomOrderableItem)
                {
                    case "Purple Ice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Liquid Apple":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Cube Juice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains("poison");
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Apple Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Keg Tonic":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                    case "Everything Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        isSuccessful = false;
                        break;
                }
            }
            
        }

    }

    private float CompletedSuccessfully()
    {
        var randomTipAmount = (float)UnityEngine.Random.Range(1, 501) / (float)100;
        var newTotal = tipsTotal + randomTipAmount;

        orderComplete = true;
        tipsText.text = $"\n<u>Tips</u>\n  ${tipsTotal}\n<u>+ ${randomTipAmount}</u>\n${newTotal}";

        Instantiate(smokeEffect, orderCompleteBox.transform);
        //AudioSource.PlayClipAtPoint(soundName, transform.position);

        return newTotal;
    }

    private float CompletedNotSuccessfully()
    {
        var randomPenaltyAmount = (float)UnityEngine.Random.Range(200, 501) / (float)100;
        var newTotal = tipsTotal - randomPenaltyAmount;

        orderComplete = true;
        tipsText.text = $"\n<u>Tips</u>\n  ${tipsTotal}\n<u>- ${randomPenaltyAmount}</u>\n${newTotal}";

        Instantiate(smokeEffect, orderCompleteBox.transform);
        //AudioSource.PlayClipAtPoint(soundName, transform.position);

        return newTotal;
    }
}
