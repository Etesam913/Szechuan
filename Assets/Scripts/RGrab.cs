using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGrab : MonoBehaviour
{
    static public bool hold = true;
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
        if (other.gameObject.tag == "PlateBowlBusboy")
        {
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
