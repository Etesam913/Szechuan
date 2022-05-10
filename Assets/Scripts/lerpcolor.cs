using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpcolor : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float speed = 1.0f;
    float startTime;
    static public bool is_water_on = false;
    int count = 0;
    float t = 0;
    float t_old = 0;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        GetComponent<Renderer>().material.color = startColor;
        GetComponent<BoxCollider>().isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (is_water_on) {
            t = ((Time.time - startTime) / 5) + t_old;
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "WaterOn") {
            t_old = t;
            is_water_on = true;
            count = (2*count) + 1;
            startTime = Time.time;
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        if (other.gameObject.tag == "floor_busboy")
        {
            if (LGrab.hold == false && RGrab.hold == false)
            {
                GetComponent<BoxCollider>().isTrigger = false;
                GetComponent<Rigidbody>().useGravity = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "WaterOn")
        {
            is_water_on = false;
            if (RightSinkButt.flagbool == 0)
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }


    }
}
