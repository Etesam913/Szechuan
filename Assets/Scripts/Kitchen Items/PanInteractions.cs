using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanInteractions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("sliced_onion") || other.gameObject.name.Contains("sliced_carrot") ||
            other.gameObject.name.Contains("sliced_bell_pepper"))
        {
            other.transform.parent = transform;
        }
    }

   
}