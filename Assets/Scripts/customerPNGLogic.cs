using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerPNGLogic : MonoBehaviour
{

    public GameObject measureBox;
    public int customerVideoNumber;
    public bool customerImposter;

    public bool isThisImposter;
    public int thisVideoNumber;

    public GameObject thisImage1;
    public GameObject thisImage2;
    public GameObject thisImage3;
    public GameObject thisImage4;

    public int frameTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        frameTimer += 1;


        customerVideoNumber = measureBox.GetComponent<materialIndexTest>().customerVideoNumber;
        customerImposter = measureBox.GetComponent<materialIndexTest>().isImposterRound;



        if ((isThisImposter == customerImposter) && (customerVideoNumber == thisVideoNumber))
        {


            if (frameTimer > 0)
            {
                thisImage1.SetActive(true);
                thisImage2.SetActive(false);
                thisImage3.SetActive(false);
                thisImage4.SetActive(false);
            }

            if (frameTimer > 60)
            {
                thisImage1.SetActive(false);
                thisImage2.SetActive(true);
                thisImage3.SetActive(false);
                thisImage4.SetActive(false);
            }

            if (frameTimer > 120)
            {
                thisImage1.SetActive(false);
                thisImage2.SetActive(false);
                thisImage3.SetActive(true);
                thisImage4.SetActive(false);
            }

            if (frameTimer > 180)
            {
                thisImage1.SetActive(false);
                thisImage2.SetActive(false);
                thisImage3.SetActive(false);
                thisImage4.SetActive(true);
            }

            if (frameTimer > 240)
            {

                frameTimer = 0;
            }

        }
        else
        {

            thisImage1.SetActive(false);
            thisImage2.SetActive(false);
            thisImage3.SetActive(false);
            thisImage4.SetActive(false);
        }

    }
}
