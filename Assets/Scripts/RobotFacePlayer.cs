using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RobotFacePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject chalkboard;
    public GameObject customer;

    public bool customerHasOrdered;

    private bool lookedAtChalkboard = false;

    void Update()
    {
        //var customerHasOrdered = customer.GetComponent<CustomerController>().displayedOrder;
        if (player != null)
        {
            this.transform.LookAt(player.transform); 
            transform.Rotate(0, 180, 0);

            Vector3 angles = transform.rotation.eulerAngles;
            angles.x = 0;
            angles.z = 0;

            transform.rotation = Quaternion.Euler(angles);
        }    
    }
}
