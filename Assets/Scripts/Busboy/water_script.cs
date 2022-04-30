using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_script : MonoBehaviour
{
    // Start is called before the first frame update
    private int updates_time;
    public GameObject sphere;
    public Animator animator;
    void Start()
    {
        updates_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updates_time += 1;
        if (((updates_time % 90) == 0) || ((updates_time % 91) == 0) || ((updates_time % 92) == 0) ||
            ((updates_time % 93) == 0) || ((updates_time % 94) == 0) || ((updates_time % 95) == 0) ||
            ((updates_time % 96) == 0) || ((updates_time % 97) == 0) || ((updates_time % 98) == 0) ||
            ((updates_time % 99) == 0) || ((updates_time % 100) == 0))

        {
            animator.SetBool("water_anim", false);
            sphere.GetComponent<MeshRenderer>().enabled = true;
        }
        else {
            animator.SetBool("water_anim", true);
            sphere.GetComponent<MeshRenderer>().enabled = false;
        }
        if (updates_time % 100 == 0) {
            updates_time = 0;
        }
    }
}
