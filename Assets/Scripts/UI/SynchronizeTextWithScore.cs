using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SynchronizeTextWithScore : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();   
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Math.Round(gameManager.points).ToString() + "/ 20";
    }
}
