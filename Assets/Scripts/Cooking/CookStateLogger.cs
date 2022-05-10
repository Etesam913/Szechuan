using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookStateLogger : MonoBehaviour
{
    public GameObject plateTrigger;

    public class CookedItem
    {
        public string item = "";
        public FoodCookedState.CookState cs = FoodCookedState.CookState.Undercooked;
    }
    public List<CookedItem> cookedList = new List<CookedItem>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    Add each child of the plate to a list,
    including their name and cooked state enum.
    */
    public void addtoList() {
        foreach(Transform child in plateTrigger.transform) {
            FoodCookedState fcs = child.GetComponent<FoodCookedState>();
            CookedItem ci = new CookedItem();
            ci.item = child.name;
            ci.cs = fcs.cookState;
            cookedList.Add(ci);
            print(ci.item);
            print(ci.cs);
        }
    }
}
