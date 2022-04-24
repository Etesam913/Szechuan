using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateFoodInteractions : MonoBehaviour
{
    // Start is called before the first frame update
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
        // Make plate the parent of food when placed in plate
        if (_gameManager.interactableFoodSet.Contains(other.gameObject.name))
        {
            other.transform.parent = transform;
        }
    }
}
