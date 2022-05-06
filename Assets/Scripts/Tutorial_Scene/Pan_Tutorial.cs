using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pan_Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    float x_old;
    float x;
    float z_old;
    float z;
    static public bool panDone = false;
    GameObject obj;
    void Start()
    {
        obj = GameObject.FindWithTag("Pan");
        x = transform.position.x;
        z = transform.position.z;
        z_old = z;
        x_old = x;
        Debug.Log("Pan");
        Debug.Log(x_old);
        Debug.Log(z_old);

        //Test.updateObj(obj);
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        if (scene.name == "Tutorial")
        {
            Debug.Log("Hey there I am here, Pan has changed!!!!!");
            x = transform.position.x;
            z = transform.position.z;
            Debug.Log(x);
            Debug.Log(z);

            if ((((float)Math.Abs(x_old-x) > 0.1) || ((float)Math.Abs(z_old - z) > 0.1)) && (panDone == false)) {
                Debug.Log("Hello, Pan has changed!!!!!");
                panDone = true;
                GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (panDone) {
            obj = GameObject.FindWithTag("Fridge");
            //Test.updateObj(obj);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            if (other.gameObject.tag == "Table")
            {
                if (Pan_Tutorial.panDone == true)
                {
                    Table_Tutorial.tableDone = true;
                    GetComponent<BoxCollider>().isTrigger = false;
                }
            }
        }
    }
}
