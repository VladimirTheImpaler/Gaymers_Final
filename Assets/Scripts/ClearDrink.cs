using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDrink : MonoBehaviour
{
    public GameObject cupPropertyList;
    public GameObject chalkboard;

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
        if (other.gameObject.CompareTag("cupColliderDisk"))
        {
            cupPropertyList.GetComponent<cupLogic>().itemList.Clear();
            chalkboard.GetComponent<ChalkboardLogic>().Ingredient1Toggle.isOn = false;
            chalkboard.GetComponent<ChalkboardLogic>().Ingredient2Toggle.isOn = false;
            chalkboard.GetComponent<ChalkboardLogic>().Ingredient3Toggle.isOn = false;
            chalkboard.GetComponent<ChalkboardLogic>().Ingredient4Toggle.isOn = false;
            chalkboard.GetComponent<ChalkboardLogic>().Ingredient5Toggle.isOn = false;
        }
    }
}
