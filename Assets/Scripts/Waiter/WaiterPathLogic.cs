using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterPathLogic : MonoBehaviour
{
    public int selectedNumber = 0;
    
    // Start is called before the first frame update
    /*
    We begin by disabling all path meshes and selected table meshes.
    We iterate through the 11 tables by tag selection to do so.
    We also choose a new table so the game begins with a path chosen.
    */
    void Start()
    {
        for (int i = 1; i <= 11; i++) {
            string pathTag = "P" + i.ToString();
            string highlightedTableTag = "T" + i.ToString() + "H";
            GameObject.FindGameObjectWithTag(highlightedTableTag).GetComponent<MeshRenderer>().enabled = false;

            MeshRenderer[] rs = GameObject.FindGameObjectWithTag(pathTag).GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer r in rs)
                r.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    There are eleven tables, so we pick at random one of
    the tables for the next delivery.

    There are two table objects, one regular and one highlighted.
    We disable the regular object and enable the golden, highlighted one.
    We enable the wayfiniding path to the table so the user knows where to go.
    */
    public void chooseNewTable() {
        selectedNumber = Random.Range(1, 12);

        string tableTag = "T" + selectedNumber.ToString();
        string pathTag = "P" + selectedNumber.ToString();
        string highlightedTableTag = tableTag + "H";

        GameObject.FindGameObjectWithTag(tableTag).GetComponent<MeshRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag(highlightedTableTag).GetComponent<MeshRenderer>().enabled = true;

        MeshRenderer[] rs = GameObject.FindGameObjectWithTag(pathTag).GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer r in rs)
            r.enabled = true;
    }

    /*
    When the game starts, we run choose new table and disappear the UI.
    */
    public void startWaiterStage() {
        chooseNewTable();
    }
}
