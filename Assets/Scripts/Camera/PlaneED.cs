using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneED : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plane;
    
    void Start()
    {
        plane.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FOVButton.isfov)
            plane.GetComponent<MeshRenderer>().enabled = true;
        else
            plane.GetComponent<MeshRenderer>().enabled = false;
    }
}
