using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCookedState : MonoBehaviour
{
    private float timeCooked = 0.0f;

    static public float cookedTime;
    static public float overcookedTime;

    [SerializeField] private Material cookedMat;
    [SerializeField] private Material overcookedMat;

    enum CookState
    {
        Undercooked = 0,
        Perfect = 1,
        Overcooked = 2,
        Nopan = 3
    }

    static public bool overcooked = false;
    static public bool undercooked = false;
    static public bool perfection_cook = false;
    private CookState cookState = CookState.Nopan;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(cookState){ 
            case CookState.Nopan:
            {
                overcooked = false;
                undercooked = false;
                perfection_cook = false;
                break;
            }
            case CookState.Undercooked:
            {
                    overcooked = false;
                    undercooked = true;
                    perfection_cook = false;
                    break;
            }
            case CookState.Perfect:
            {
                    overcooked = false;
                    undercooked = false;
                    perfection_cook = true;
                    break;
            }
            case CookState.Overcooked:
            {
                    overcooked = true;
                    undercooked = false;
                    perfection_cook = false;
                    break;
            }
        }
    }

    public void IncreaseTimeCooked(float t)
    {
        if(t > 0.0f)
        {
            timeCooked += t;
            if (cookState == CookState.Nopan) {
                cookState = CookState.Undercooked;
            }
            else if((cookState == CookState.Undercooked) 
                && timeCooked >= cookedTime
                ) // perfectly cooked
            {
                cookState = CookState.Perfect;
                GetComponent<MeshRenderer>().material = cookedMat;
            }
            else if(cookState == CookState.Perfect && timeCooked >= overcookedTime) // overcooked
            {
                cookState = CookState.Overcooked;
                GetComponent<MeshRenderer>().material = overcookedMat;
            }
            Timer_button.dashboard(cookedTime - timeCooked);
        }
    }

    public void NoInteraction() {
        cookState = CookState.Nopan;
        overcooked = false;
        undercooked = false;
        perfection_cook = false;
    }

}
