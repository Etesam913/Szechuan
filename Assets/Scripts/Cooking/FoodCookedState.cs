using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCookedState : MonoBehaviour
{
    private float timeCooked = 0.0f;

    [SerializeField] private float cookedTime;
    [SerializeField] private float overcookedTime;

    [SerializeField] private Material cookedMat;
    [SerializeField] private Material overcookedMat;

    static public float cT_store;
    static public float oT_store;

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
        cT_store = cookedTime;
        oT_store = overcookedTime;
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
            if (((cookState == CookState.Nopan) || (cookState == CookState.Undercooked)) &&
                timeCooked < cookedTime)
            {
                cookState = CookState.Undercooked;
                Red_oucook.redon();
                Green_perfection.greenoff();
                Timer_button.slidercall_b = false;
            }
            else if ((cookState == CookState.Undercooked || cookState == CookState.Perfect)
                && timeCooked >= cookedTime && timeCooked < overcookedTime
                ) // perfectly cooked
            {
                Red_oucook.redoff();
                Green_perfection.greenon();
                cookState = CookState.Perfect;
                GetComponent<MeshRenderer>().material = cookedMat;
                Timer_button.slidercall_b = true;

            }
            else if ((cookState == CookState.Perfect || cookState == CookState.Overcooked) &&
                timeCooked >= overcookedTime) // overcooked
            {
                Red_oucook.redoff();
                Green_perfection.greenon();
                cookState = CookState.Overcooked;
                GetComponent<MeshRenderer>().material = overcookedMat;
                Timer_button.slidercall_b = true;
            }
            Timer_button.dashboard(cookedTime - timeCooked);
        }
    }

    /*public void NoInteraction() {
        cookState = CookState.Nopan;
        overcooked = false;
        undercooked = false;
        perfection_cook = false;
    }*/

}
