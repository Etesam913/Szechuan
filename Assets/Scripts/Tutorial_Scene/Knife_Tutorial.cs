using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Knife_Tutorial : MonoBehaviour
{
    float x_old;
    float x;
    float z_old;
    float z;
    static public bool knifeDone = false;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
        z_old = z;
        x_old = x;
        obj = GameObject.FindWithTag("Knife");
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            x = transform.position.x;
            z = transform.position.z;

            if ((((float)Math.Abs(x_old - x) > 0.1) || ((float)Math.Abs(z_old - z) > 0.1)) && (knifeDone == false))
            {
                if (Fridge_Tutorial.fridgeDone == true)
                {
                    knifeDone = true;
                    obj.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            if (other.gameObject.tag == "Board")
            {
                if (Knife_Tutorial.knifeDone == true)
                {
                    Board_Tutorial.boardDone = true;
                    GetComponent<BoxCollider>().isTrigger = false;
                }
            }
        }
    }
}
