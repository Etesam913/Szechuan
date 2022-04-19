using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent = null;
    }
}
