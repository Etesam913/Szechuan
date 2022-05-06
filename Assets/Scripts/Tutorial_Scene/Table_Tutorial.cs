using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Table_Tutorial : MonoBehaviour
{
    float x_old;
    float x;
    float z_old;
    float z;
    static public bool tableDone = false;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
        z_old = z;
        x_old = x;
        obj = GameObject.FindWithTag("Table");
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            x = transform.position.x;
            z = transform.position.z;

        }
    }
}
