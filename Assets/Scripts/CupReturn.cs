using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupReturn : MonoBehaviour
{
    public GameObject theCup;
    public GameObject drinkFinishZone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (drinkFinishZone.GetComponent<OrderCompleteLogic>().orderComplete == true) {
            theCup.SetActive(false);
            // poof effect here
            theCup.transform.position = GetComponent<ObjectPosition>().originPosition;
            theCup.transform.rotation = Quaternion.Euler(GetComponent<RotationTracker>().originRotationXYZ);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            // poof effect to show reactivation, or mitch's dispenser thing
            theCup.SetActive(true);

            // poof effect in front of customer, finished drink appears
        }
    }
}
