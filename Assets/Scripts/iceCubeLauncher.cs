using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCubeLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 10f, 0f), ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(new Vector3(1f, 1f, 1f), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
