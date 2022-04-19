using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateInteractable : MonoBehaviour
{

    public GameObject waiterWrapper;
    private WaiterPathLogic myWaiterPathLogic;

    // Start is called before the first frame update
    /*
    We store the WaiterPathLogic from the WaiterWrapper component
    to access later.
    */
    void Start()
    {
        myWaiterPathLogic = waiterWrapper.GetComponent<WaiterPathLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    If a collision occurs between [EXAMPLE PLATE] and object,
    we check if the object is the selected table. If it is, we
    disable the selected table mesh, enable the normal table mesh,
    disable the path mesh, and finally, choose a new table.
    */
    private void OnTriggerEnter(Collider other) {
        int table = getSelectedNumber();
        string tableTag = "T" + table.ToString();
        string pathTag = "P" + table.ToString();
        if (other.gameObject.CompareTag(tableTag + "H")) {
            GameObject.FindGameObjectWithTag(tableTag).GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag(tableTag + "H").GetComponent<MeshRenderer>().enabled = false;
            MeshRenderer[] rs = GameObject.FindGameObjectWithTag(pathTag).GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer r in rs)
                r.enabled = false;
            
            myWaiterPathLogic.chooseNewTable();
            print("Plate dropped on correct table: " + table.ToString() + "!");
        }
    }

    /*
    Grabs selected number from the waiter wrapper script.
    */
    int getSelectedNumber() {
        return myWaiterPathLogic.selectedNumber;
    }
}
