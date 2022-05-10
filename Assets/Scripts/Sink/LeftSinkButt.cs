using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSinkButt : MonoBehaviour
{
    public GameObject tap;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leftclick() {
        if (RightSinkButt.flagbool == 4)
        {
            water.GetComponent<MeshRenderer>().enabled = true;
            RightSinkButt.flagbool = 3;
            tap.transform.eulerAngles = new Vector3(0, 0, 60);
        }
        else if (RightSinkButt.flagbool == 3)
        {
            water.GetComponent<MeshRenderer>().enabled = true;
            RightSinkButt.flagbool = 2;
            tap.transform.eulerAngles = new Vector3(0, 0, 40);
        }
        else if (RightSinkButt.flagbool == 2)
        {
            water.GetComponent<MeshRenderer>().enabled = true;
            RightSinkButt.flagbool = 1;
            tap.transform.eulerAngles = new Vector3(0, 0, 20);
        }
        else if (RightSinkButt.flagbool == 1)
        {
            water.GetComponent<MeshRenderer>().enabled = false;
            RightSinkButt.flagbool = 0;
            tap.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        /*leftbool = true;
        if ((tap.transform.eulerAngles.z > 0) && (tap.transform.eulerAngles.z <= 100)) {
            tap.transform.eulerAngles += new Vector3(0, 0, -20);
        }
        else if ((tap.transform.eulerAngles.z > 100) && (tap.transform.eulerAngles.z < 250))
        {
            tap.transform.eulerAngles = new Vector3(0, 0, 100);
        }
        else if (((tap.transform.eulerAngles.z > 250) && (tap.transform.eulerAngles.z <= 360)) || (tap.transform.eulerAngles.z == 0))
        {
            tap.transform.eulerAngles = new Vector3(0, 0, 0);
        }*/
    }
}
