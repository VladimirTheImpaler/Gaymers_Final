using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liquidLogic : MonoBehaviour
{

    public int life;
    public bool stuck = false;
    public AudioClip cleaning_SFX;
    public AudioClip floorDrop_SFX;

    // Start is called before the first frame update
    void Start()
    {

        life = 100;
    }

    // Update is called once per frame
    void Update()
    {

        this.life -= 1;

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
            AudioSource.PlayClipAtPoint(cleaning_SFX, transform.position);

        }else if (other.gameObject.CompareTag("juicerFreezeBlock"))
        {
            stuck = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.life = 99999999;
            AudioSource.PlayClipAtPoint(floorDrop_SFX, transform.position);
        }
        else
        {
            stuck = false;
            //other.gameObject.SetActive(true);
        }
    }



}
