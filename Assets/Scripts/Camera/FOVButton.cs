using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVButton : MonoBehaviour
{
    public static bool isfov = false;
    public static bool isfov2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fov_click() {
        isfov = !isfov;
    }

    public void fov_2_click()
    {
        isfov2 = !isfov2;
    }
}
