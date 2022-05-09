using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateInteractable : MonoBehaviour
{

    public GameObject waiterWrapper;
    private Vector3 platePosition;

    private bool timerStarted = false;
    private float offsetTime = 1f;
    private float timer;

    public GameObject blackScreen;
    public GameObject origin;
    public GameObject nlCanvas;
    public GameObject gameManager;

    public GameObject plateTrigger;

    
    private WaiterPathLogic myWaiterPathLogic;
    private CookStateLogger myCookStateLogger;

    private bool fadeToBlack = false;
    

    // Start is called before the first frame update
    /*
    We store the WaiterPathLogic from the WaiterWrapper component
    to access later.
    */
    void Start()
    {
        myWaiterPathLogic = waiterWrapper.GetComponent<WaiterPathLogic>();
        myCookStateLogger = gameManager.GetComponent<CookStateLogger>();
        platePosition = new Vector3(-4.277f, 0f, 41.326f);
    }

    void Update() {
        if (timerStarted) {
            timer += Time.deltaTime;
            if(timer > offsetTime) {
                timer = 0f;
                this.transform.localPosition = platePosition;
                this.transform.eulerAngles = new Vector3(0, -90f, 0);
                timerStarted = false;
                //print(this.transform.position);
                destroyPlateChildren();
                myCookStateLogger.addtoList();
            }
        }

        if (fadeToBlack) {
            //print(blackScreen.GetComponent<RawImage>().color.a);
            if (blackScreen.GetComponent<RawImage>().color.a <= 1) {
                Color objectColor = blackScreen.GetComponent<RawImage>().color;
                float fadeAmount = objectColor.a + (0.5f * Time.deltaTime);
                blackScreen.GetComponent<RawImage>().color = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            } else {
                fadeToBlack = false;
                Color objectColor = blackScreen.GetComponent<RawImage>().color;
                blackScreen.GetComponent<RawImage>().color = new Color(objectColor.r, objectColor.g, objectColor.b, 0f);
                origin.transform.position = new Vector3(100f, 100f, 100f);
                nlCanvas.SetActive(true);
            }
        }
    }


    /*
    If a collision occurs between [EXAMPLE PLATE] and object,
    we check if the object is the selected table. If it is, we
    disable the selected table mesh, enable the normal table mesh,
    disable the path mesh, and finally, choose a new table.
    */
    private void OnTriggerEnter(Collider other) {
        int tableNumber = getSelectedNumber();
        string tableTag = "T" + tableNumber.ToString();
        string pathTag = "P" + tableNumber.ToString();
        if (tableNumber != 0 && other.gameObject.CompareTag(tableTag + "H")) {
            GameObject.FindGameObjectWithTag(tableTag).GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag(tableTag + "H").GetComponent<MeshRenderer>().enabled = false;
            MeshRenderer[] rs = GameObject.FindGameObjectWithTag(pathTag).GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer r in rs)
                r.enabled = false;
            
            //myWaiterPathLogic.chooseNewTable();
            print("Plate dropped on correct table: " + tableNumber.ToString() + "!");
            timerStarted = true;
            fadeToBlack = true;
            this.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            this.gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    /*
    Grabs selected number from the waiter wrapper script.
    */
    int getSelectedNumber() {
        return myWaiterPathLogic.selectedNumber;
    }

    /*
    We get rid of any children of plate items.
    */
    void destroyPlateChildren() {
        foreach(Transform child in plateTrigger.transform) {
            Destroy(child.gameObject);
        }
    }
}
