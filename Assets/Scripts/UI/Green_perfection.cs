using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_perfection : MonoBehaviour
{
    // Start is called before the first frame update
    private CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (FoodCookedState.perfection_cook)
        {
            canvasGroup.alpha = 1;
        }
        else {
            canvasGroup.alpha = 0;
        }


    }
}
