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

    public enum CookState
    {
        Undercooked,
        Perfect,
        Overcooked
    }

    public CookState cookState = CookState.Undercooked;


    public void IncreaseTimeCooked(float t)
    {
        if(t > 0.0f)
        {
            timeCooked += t;

            if(cookState == CookState.Undercooked && timeCooked >= cookedTime) // perfectly cooked
            {
                cookState = CookState.Perfect;
                GetComponent<MeshRenderer>().material = cookedMat;
            }
            else if(cookState == CookState.Perfect && timeCooked >= overcookedTime) // overcooked
            {
                cookState = CookState.Overcooked;    
                GetComponent<MeshRenderer>().material = overcookedMat;
            }
        }
    }
}