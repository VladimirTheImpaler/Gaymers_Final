using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderCompleteLogic : MonoBehaviour
{
    public GameObject cupPropertyList;
    public GameObject customer;
    public GameObject cup;

    public GameObject cherryOnDrink;
    public GameObject lemonOnDrink;
    public GameObject strawOnDrink;
    public GameObject umbrellaOnDrink;
    public GameObject umbrellaBallOnDrink;

    public GameObject orderCompleteBox;
    public GameObject smokeEffect;

    public TextMeshProUGUI tipsText;

    public float tipsTotal = 0.00f;

    public bool orderComplete;
    public bool isSuccessful;
    public bool chargedTip;

    public AudioClip success_SFX;
    public AudioClip failure_SFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mainCup"))
        {
            var cupList = cupPropertyList.GetComponent<cupLogic>().itemList;
            var randomOrderableItem = customer.GetComponent<CustomerController>().randomOrderableItem;
            var isImposterRound = customer.GetComponent<CustomerController>().isImposterRound;
            var garnish = customer.GetComponent<CustomerController>().randomGarnish;

            if (!isImposterRound)
            {
                switch (randomOrderableItem)
                {
                    case "Purple Ice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains(garnish.ToLower());
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Liquid Apple":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower());
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Cube Juice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains(garnish.ToLower());
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Apple Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains(garnish.ToLower());
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Keg Tonic":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower());
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Everything Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower());
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                }
            }
            else
            {
                switch (randomOrderableItem)
                {
                    case "Purple Ice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Liquid Apple":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Cube Juice":
                        isSuccessful = cupList.Contains("iceCube") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains("poison");
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Apple Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Keg Tonic":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
                        break;
                    case "Everything Smoothie":
                        isSuccessful = cupList.Contains("kegLiquid") && cupList.Contains("appleJuice") && cupList.Contains("shavedIce") && cupList.Contains("tonic") && cupList.Contains(garnish.ToLower()) && cupList.Contains("poison");
                        if (!chargedTip)
                        {
                            tipsTotal = isSuccessful ? CompletedSuccessfully() : CompletedNotSuccessfully();
                        }
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
        chargedTip = true;
        tipsText.text = $"\n<u>Tips</u>\n  ${tipsTotal}\n<u>+ ${randomTipAmount}</u>\n${newTotal}";

        disableGarnishes();
        Instantiate(smokeEffect, orderCompleteBox.transform);
        AudioSource.PlayClipAtPoint(success_SFX, transform.position);

        return newTotal;
    }

    private float CompletedNotSuccessfully()
    {
        var randomPenaltyAmount = (float)Math.Round((float)UnityEngine.Random.Range(200, 501) / (float)100, 2);
        var newTotal = (float)Math.Round(tipsTotal - randomPenaltyAmount, 2);

        orderComplete = true;
        chargedTip = true;
        tipsText.text = $"\n<u>Tips</u>\n  ${tipsTotal}\n<u>- ${randomPenaltyAmount}</u>\n${newTotal}";

        disableGarnishes();
        Instantiate(smokeEffect, orderCompleteBox.transform);
        AudioSource.PlayClipAtPoint(failure_SFX, transform.position);

        return newTotal;
    }

    private void disableGarnishes()
    {

        cherryOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = false;
        lemonOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = false;
        strawOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = false;
        umbrellaOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = false;
        umbrellaBallOnDrink.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
