using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slidertimer : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider AudioSlider;
    void Start()
    {
        AudioSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PanCookingInteractions.interact)
        {
            AudioSlider.value += Time.deltaTime / FoodCookedState.cT_store;
        }
        else {
            AudioSlider.value = 0;
        }
        
    }
}
