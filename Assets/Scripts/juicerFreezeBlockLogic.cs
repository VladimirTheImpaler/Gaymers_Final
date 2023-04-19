using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juicerFreezeBlockLogic : MonoBehaviour
{

    public bool hasJuice = false;
    public int numLiquid = 0;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("appleJuice") || other.gameObject.CompareTag("kegLiquid"))
        {

            numLiquid += 1;
            hasJuice = true;
        }
        else
        {

            hasJuice = false;
        }
    }
}
