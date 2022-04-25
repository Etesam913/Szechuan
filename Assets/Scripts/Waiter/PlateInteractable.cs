using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInteractable : MonoBehaviour
{

    public GameObject waiterWrapper;
    private WaiterPathLogic myWaiterPathLogic;
    private Vector3 platePosition;

    private bool timerStarted = false;
    private float offsetTime = 1f;
    private float timer;

    // Start is called before the first frame update
    /*
    We store the WaiterPathLogic from the WaiterWrapper component
    to access later.
    */
    void Start()
    {
        myWaiterPathLogic = waiterWrapper.GetComponent<WaiterPathLogic>();
        platePosition = new Vector3(-6.3f, -0.04f, 34.7f);
    }

    void Update() {
        if (timerStarted) {
            timer += Time.deltaTime;
            if(timer > offsetTime) {
                timer = 0f;
                this.transform.position = platePosition;
                this.transform.eulerAngles = new Vector3(0, 0, 0);
                timerStarted = false;
                print(this.transform.position);
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
        if (other.gameObject.CompareTag(tableTag + "H")) {
            GameObject.FindGameObjectWithTag(tableTag).GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag(tableTag + "H").GetComponent<MeshRenderer>().enabled = false;
            MeshRenderer[] rs = GameObject.FindGameObjectWithTag(pathTag).GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer r in rs)
                r.enabled = false;
            
            myWaiterPathLogic.chooseNewTable();
            print("Plate dropped on correct table: " + tableNumber.ToString() + "!");
            timerStarted = true;
        }
    }

    /*
    Grabs selected number from the waiter wrapper script.
    */
    int getSelectedNumber() {
        return myWaiterPathLogic.selectedNumber;
    }
}
