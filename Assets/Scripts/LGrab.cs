using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LGrab : MonoBehaviour
{
    static public bool hold = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlateBowlBusboy") {
            other.isTrigger = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            hold = true;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlateBowlBusboy")
        {
            other.isTrigger = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            hold = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlateBowlBusboy")
        {
            other.isTrigger = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            hold = false;
        }

    }

}
