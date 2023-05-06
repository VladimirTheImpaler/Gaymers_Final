using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR.InteractionSystem.Sample;

public class RobotController : MonoBehaviour
{
    public GameObject robot;
    public GameObject robotTalking;
    public GameObject robotWriting;
    public GameObject speechBubble;
    public GameObject customer;
    public GameObject chalkboard;

    public TextMeshProUGUI robotText;

    public float speed = 1.0f;
    public float timer = 0f;
    float chalkboardWriteDelay = 0;

    public bool isTutorial = true;
    public bool isTalking = false;
    public bool needsHint = false;
    public bool canMoveX = false;
    public bool canMoveY = false;
    public bool canMoveYTwo = false;
    public bool canMoveZ = false;
    public bool inFinalPosition = false;
    public bool atChalkboard = false;
    public bool orderOnChalkboard;
    public bool canMoveBackFromChalkboard = false;
    private bool unlockY = true;
    public bool hasMovedForCurrentCustomer = false;
    private bool customerHasOrdered;

    private Vector3 robotStartPos = new Vector3(2, 5.5f, -9);
    private Vector3 robotFinalPos = new Vector3(-11f, 5.5f, -5.5f);
    private Vector3 robotChalkboardPos = new Vector3(-0.5f, 9f, -1.5f);

    WaitForSeconds _delayBetweenCharactersYieldInstruction;

    void Start()
    {
        robot.transform.position = robotStartPos;
        robotTalking.transform.position = robotStartPos;
        robotWriting.transform.position = robotStartPos;
        robot.SetActive(true);
        robotTalking.SetActive(false);
        robotWriting.SetActive(false);
        speechBubble.SetActive(false);
    }

    void Update()
    {
        customerHasOrdered = customer.GetComponent<CustomerController>().displayedOrder;

        // var takingTooLong = false;

        if (isTutorial)
        {
            tutorialDialogue();
        }

        if (!isTutorial && !inFinalPosition)
        {
            canMoveX = true;
            MoveToFinalPosition();
        }

        /*if (takingTooLong)
        {
            GiveRandomHint();
        }*/

        if (!hasMovedForCurrentCustomer)
        {
            if (customerHasOrdered && !atChalkboard && !orderOnChalkboard)
            {
                canMoveY = true;
                MoveToChalkboard();
            }

            if (canMoveBackFromChalkboard && orderOnChalkboard)
            {
                canMoveZ = true;
                MoveFromChalkboardToRestingPos();
            } 
        }
    }

    private void tutorialDialogue()
    {
        robot.SetActive(false);
        robotTalking.SetActive(true);
        timer += Time.deltaTime;
        if (timer <= 2.5f)
        {
            speechBubble.SetActive(true);
            robotText.text = "Well howdy, there partner!";
        }
        else if (timer <= 7.5f)
        {
            robotText.text = "The time-regulation committee has sent you here to tie up a few loose ends.";
        }
        else if (timer <= 12.5f)
        {
            robotText.text = "Some vagrants have wandered into a timeline they don’t belong in, ";
        }
        else if (timer <= 17.5f)
        {
            robotText.text = "and your job is to find out who they are and remove them… if ya know what I mean.";
        }
        else if (timer <= 22.5f)
        {
            robotText.text = "You’ll pose as a bartender here, make drinks, and keep a low profile.";
        }
        else if (timer <= 27.5f)
        {
            robotText.text = "Eliminate the vagrants and you’ll be out of here in no time.";
        }
        else if (timer <= 32.5f)
        {
            robotText.text = "Now onto how make the drinks...";
        }
        else if (timer <= 37.5f)
        {
            robotText.text = "Use the bottles on the counter to pour ingredients into the cup.";
        }
        else if (timer <= 42.5f)
        {
            robotText.text = "The ice pick and scoop can be used to add ice.";
        }
        else if (timer <= 47.5f)
        {
            robotText.text = "You will earn a tip for every successful order.";
        }
        else if (timer <= 52.5f)
        {
            robotText.text = "However you'll be penalized for having the wrong ingredients.";
        }
        else if (timer <= 57.5f)
        {
            robotText.text = "If at any point you mess up your order, you can put the cup in the sink to start over.";
        }
        else if (timer <= 62.5f)
        {
            robotText.text = "The vagrants need to be poisoned in order to protect everyone else.";
        }
        else if (timer <= 67.5f)
        {
            robotText.text = "Whenever you spill liquid on the ground, you'll have to sweep them up.";
        }
        else if (timer <= 72.5f)
        {
            robotText.text = "You'll know you need to do this when your chore list updates on the chalkboard.";
        }
        else if (timer <= 77.5f)
        {
            robotText.text = "That should be enough to get you started.";
        }
        else if (timer <= 82.5)
        {
            robotText.text = "Good luck!";
        }
        else if (timer > 82.5)
        {
            speechBubble.SetActive(false);
            robotTalking.SetActive(false);
            isTutorial = false;
            return;
        }
    }

    private void MoveToFinalPosition()
    {
        robot.SetActive(true);
        if (canMoveX && robot.transform.position.x > -11f)
        {
            float xNew = robot.transform.position.x + -1 * speed * Time.deltaTime;

            robot.transform.position = new Vector3(xNew, robotTalking.transform.position.y, -9f);
        }
        else if (robot.transform.position.x <= -11f)
        {
            canMoveX = false;
            canMoveZ = true;
        }

        if (canMoveZ && robot.transform.position.z < -5.5 && !canMoveX)
        {
            float zNew = robot.transform.position.z + speed * Time.deltaTime;

            robot.transform.position = new Vector3(-11f, robotTalking.transform.position.y, zNew);
        } else if (robot.transform.position.z >= -5.5)
        {
            robot.transform.position = new Vector3(-11f, 5.5f, -5.5f);
            robotTalking.transform.position = new Vector3(-11f, 5.5f, -5.5f);
            inFinalPosition = true;
            canMoveZ = false;
        }
    }

    private void MoveToChalkboard()
    {
        if (canMoveY && robot.transform.position.y < 7.5f)
        {
            float yNew = robot.transform.position.y + speed * Time.deltaTime;

            robot.transform.position = new Vector3(-11f, yNew, -5.5f);
        }
        else if (robot.transform.position.y >= 7.5f)
        {
            canMoveY = false;
            canMoveX = true;
        }

        if (canMoveX && robot.transform.position.x < -0.5 && !canMoveY)
        {
            float xNew = robot.transform.position.x + speed * Time.deltaTime;

            robot.transform.position = new Vector3(xNew, robot.transform.position.y, -5.5f);
        }
        else if (robot.transform.position.x >= -0.5)
        {
            canMoveX = false;
            canMoveYTwo = true;
        }

        if (canMoveYTwo && robot.transform.position.y < 9.0f && !canMoveX)
        {
            float yNewTwo = robot.transform.position.y + speed * Time.deltaTime;

            robot.transform.position = new Vector3(-0.5f, yNewTwo, -5.5f);
        }
        else if (robot.transform.position.y >= 9f)
        {
            canMoveYTwo = false;
            canMoveZ = true;
        }

        if (canMoveZ && robot.transform.position.z < -1.5f)
        {
            float zNew = robot.transform.position.z + speed * Time.deltaTime;

            robot.transform.position = new Vector3(-0.5f, 9f, zNew);
        }
        else if (robot.transform.position.z >= -1.5f)
        {
            robot.transform.position = new Vector3(-0.5f, 9f, -1.5f);
            canMoveZ = false; 
            atChalkboard = true;
        }

        // Supposed to switch to writing and delay for a few seconds
        /*if (robot.transform.position == robotChalkboardPos && chalkboardWriteDelay < 50f)
        {
            robot.SetActive(false);
            robotWriting.SetActive(true);
            robotWriting.transform.position = robotChalkboardPos;
            chalkboardWriteDelay += 1.0f;
        }*/
    }

    private void MoveFromChalkboardToRestingPos()
    {
        if (canMoveZ && robot.transform.position.z > -5.5f)
        {
            float zNew = robot.transform.position.z - speed * Time.deltaTime;

            robot.transform.position = new Vector3(-0.5f, 9f, zNew);
        }
        else if (robot.transform.position.z <= -5.5f)
        {
            canMoveZ = false;
            canMoveYTwo = true;
        }

        if (canMoveYTwo && robot.transform.position.y > 7.5f && !canMoveZ)
        {
            float yNewTwo = robot.transform.position.y - speed * Time.deltaTime;

            robot.transform.position = new Vector3(-0.5f, yNewTwo, -5.5f);
        }
        else if (robot.transform.position.y <= 7.5f)
        {
            canMoveYTwo = false;
            canMoveX = true;
        }

        if (canMoveX && robot.transform.position.x > -11f && !canMoveYTwo)
        {
            float xNew = robot.transform.position.x - speed * Time.deltaTime;

            robot.transform.position = new Vector3(xNew, robot.transform.position.y, -5.5f);
        }
        else if (robot.transform.position.x <= -11f)
        {
            canMoveX = false;
            canMoveY = true;
        }

        if (canMoveY && robot.transform.position.y > 5.5f && !canMoveX && !canMoveYTwo && !canMoveZ)
        {
            float yNew = robot.transform.position.y - speed * Time.deltaTime;

            robot.transform.position = new Vector3(-11f, yNew, -5.5f);
        }
        else if (robot.transform.position.y <= 5.5f)
        {
            robot.transform.position = robotFinalPos;
            canMoveY = false;
            atChalkboard = false;
            orderOnChalkboard = false;
            canMoveBackFromChalkboard = false;
            hasMovedForCurrentCustomer = true;
        }
    }

    private void GiveRandomHint()
    {
        var randomHint = UnityEngine.Random.Range(0, 5);

        robotTalking.SetActive(true);
        robot.SetActive(false);

        switch (randomHint)
        {
            case 0:
                robotText.text = "*Shhh* The green bottle is to poison the alien...";
                break;
            case 1:
                robotText.text = "Put an apple in the red juicer and spin the crank for apple juice!";
                break;
            case 2:
                robotText.text = "Hint3";
                break;
            case 3:
                robotText.text = "Hint4";
                break;
            case 4:
                robotText.text = "Hint5";
                break;
        }
        speechBubble.SetActive(true);
    }

}
