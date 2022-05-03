using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_oucook : MonoBehaviour
{
    // Start is called before the first frame update
    static private CanvasGroup canvasGroup;
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if ((FoodCookedState.overcooked || FoodCookedState.undercooked))
        {
            canvasGroup.alpha = 1;
        }
        else
        {
            if (Green_perfection.green_on == false)
            {
                canvasGroup.alpha = 1;
            }
            else 
            {
                canvasGroup.alpha = 0;
            }
            
        }*/
    }

    static public void redon()
    {
        canvasGroup.alpha = 1;
    }

    static public void redoff()
    {
        canvasGroup.alpha = 0;
    }
}
