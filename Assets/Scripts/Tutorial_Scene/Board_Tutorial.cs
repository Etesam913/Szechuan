using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board_Tutorial : MonoBehaviour
{
    float x_old;
    float x;
    float z_old;
    float z;
    static public bool boardDone = false;
    GameObject knife_obj;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
        z_old = z;
        x_old = x;
        knife_obj = GameObject.FindWithTag("Knife");
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

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            if (other.gameObject.tag == "Knife")
            {
                if (Knife_Tutorial.knifeDone == true)
                {
                    boardDone = true;
                    GetComponent<BoxCollider>().isTrigger = false;
                }
            }
            if (other.gameObject.tag == "Floor")
            {
                GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}
