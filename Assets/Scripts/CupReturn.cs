using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupReturn : MonoBehaviour
{
    public GameObject drinkFinishZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drinkFinishZone.GetComponent<OrderCompleteLogic>().orderComplete == true) {
        // may need to unparent from hand if currently held
        // wait for a beat
        // poof effect, teleport cup to orginal position (reset velocity & rotation)
        // poof effect in front of customer, finished drink appears
        }
    }
}
