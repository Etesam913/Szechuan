using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanInteractions : MonoBehaviour
{

    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        // Make the pan the parent of food when placed in pan
        if (_gameManager.interactableFoodSet.Contains(other.gameObject.name))
        {
            other.transform.parent = transform;
        }
        
    }
}