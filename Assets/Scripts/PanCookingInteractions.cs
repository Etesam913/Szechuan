using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCookingInteractions : MonoBehaviour
{
    public GameObject foodParent;

    private string stoveTriggerName = "stove_trigger";
    private bool cooking = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(cooking) // Pan is on stove
        {
            float dt = Time.deltaTime;
            foreach(Transform childTrans in foodParent.transform)
            {
                var food = childTrans.gameObject;
                var cookedState = food.GetComponent<FoodCookedState>();
                if(cookedState != null)
                    cookedState.IncreaseTimeCooked(dt);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals(stoveTriggerName))
        {
            cooking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name.Equals(stoveTriggerName))
        {
            cooking = false;
        }
    }

}
