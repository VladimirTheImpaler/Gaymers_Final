using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liquidLogic : MonoBehaviour
{

    public int life = 4000;
    public bool stuck = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!(this.gameObject.GetComponent<ObjectPosition>().currentPosition.y < -3.6f))
        {

            this.life -= 1;
        }

        if (this.life < 0)
        {

            this.life = 0;
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("broom"))
        {

            this.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(soundName, transform.position);

        }else if (other.gameObject.CompareTag("juicerFreezeBlock"))
        {
            stuck = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.life = 99999999;
            //AudioSource.PlayClipAtPoint(soundName, transform.position);
        }
        else
        {
            stuck = false;
            //other.gameObject.SetActive(true);
        }
    }



}
