using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSinkButt : MonoBehaviour
{
    static public int flagbool = 0;
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

    public void rightclick()
    {
        if (flagbool == 0)
        {
            flagbool = 1;
            tap.transform.eulerAngles = new Vector3(0, 0, 20);
            water.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (flagbool == 1) {
            flagbool = 2;
            tap.transform.eulerAngles = new Vector3(0, 0, 40);
            water.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (flagbool == 2)
        {
            flagbool = 3;
            tap.transform.eulerAngles = new Vector3(0, 0, 60);
            water.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (flagbool == 3)
        {
            flagbool = 4;
            tap.transform.eulerAngles = new Vector3(0, 0, 80);
            water.GetComponent<MeshRenderer>().enabled = true;
        }


        /*if ((tap.transform.eulerAngles.z >= 0) && (tap.transform.eulerAngles.z < 100)) 
            //|| ((tap.transform.eulerAngles.z >= 355) && (tap.transform.eulerAngles.z <= 360)))
        {
            tap.transform.eulerAngles += new Vector3(0, 0, 20);
        }
        else if ((tap.transform.eulerAngles.z >= 100) && (tap.transform.eulerAngles.z < 250))
        {
            tap.transform.eulerAngles = new Vector3(0, 0, 100);
        }
        else if ((tap.transform.eulerAngles.z > 250) && (tap.transform.eulerAngles.z < 360)) {
            tap.transform.eulerAngles = new Vector3(0, 0, 0);
        }*/

    }
}
