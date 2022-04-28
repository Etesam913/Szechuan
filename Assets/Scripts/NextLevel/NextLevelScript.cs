using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelScript : MonoBehaviour
{

    public GameObject origin;
    public GameObject nlCanvas;
    public GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //We move the player back to the restaurant and set
    //the black canvas to false.
    public void advance() {
        origin.transform.position = new Vector3(-1.153372f, -0.9505002f, 41.49769f);
        origin.transform.eulerAngles = new Vector3(origin.transform.eulerAngles.x, 180f, origin.transform.eulerAngles.z);
        nlCanvas.SetActive(false);
    }
}
