using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeED : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;

    void Start()
    {
        cube.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FOVButton.isfov2)
            cube.GetComponent<MeshRenderer>().enabled = true;
        else
            cube.GetComponent<MeshRenderer>().enabled = false;
    }
}