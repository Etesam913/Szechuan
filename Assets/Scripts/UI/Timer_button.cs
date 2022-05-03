using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_button : MonoBehaviour
{
    static private float score = 0f;
    static public bool slidercall = false;
    static public bool slidercall_b = false;
    static public Text Score;
    // Start is called before the first frame update
    public int temp = 12;
    void Start()
    {
        Score = GetComponent<Text>();
        //Score.text = temp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void dashboard(float timer) {
        if (timer > 0)
        {
            score = timer;
        }
        else {
            score = timer;
        }

        Score.text = score.ToString();

    }
}
