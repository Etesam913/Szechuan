using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fridge_Tutorial : MonoBehaviour
{
    float x_old;
    float x;
    float z_old;
    float z;
    static public bool fridgeDone = false;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
        z_old = z;
        x_old = x;
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            x = transform.position.x;
            z = transform.position.z;

            if (x_old != x || z_old != z)
            {
                if (Pan_Tutorial.panDone == true)
                    fridgeDone = true;
            }
        }

    }
}
