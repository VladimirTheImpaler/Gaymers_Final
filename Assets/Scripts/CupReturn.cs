using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupReturn : MonoBehaviour
{
    public GameObject theCup;
    public GameObject drinkFinishZone;
    public GameObject pipeCollider1;
    public GameObject pipeCollider2;

    public int meshResetTimer = 1000;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        meshResetTimer -= 1;

        if (drinkFinishZone.GetComponent<OrderCompleteLogic>().orderComplete == true) {
            
            theCup.SetActive(false);
            // poof effect here
            theCup.transform.position = GetComponent<ObjectPosition>().originPosition;
            theCup.transform.rotation = Quaternion.Euler(GetComponent<RotationTracker>().originRotationXYZ);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
 
            theCup.SetActive(true);

            // poof effect in front of customer, finished drink appears

            //deactivates pipe mesh
            meshResetTimer = 1000;
        }

        if (meshResetTimer > 0)
        {
            pipeCollider1.SetActive(false);
            pipeCollider2.SetActive(false);
        }
        else
        {
            pipeCollider1.SetActive(true);
            pipeCollider2.SetActive(true);
        }
    }
}
