using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Food that can be put into a pan, cooked, and put into a plate
    [SerializeField] private string[] interactableFood = {};

    public HashSet<string> interactableFoodSet;
    // Start is called before the first frame update
    void Start()
    {
        interactableFoodSet = new HashSet<string>(interactableFood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
