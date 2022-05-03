using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplets : MonoBehaviour
{
    public GameObject RespWater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((lerpcolor.is_water_on || lerpcolor_mug.is_water_on) &&
            (RespWater.GetComponent<MeshRenderer>().enabled == true))
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
