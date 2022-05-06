using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCookingInteractions : MonoBehaviour
{
    public GameObject foodParent;
    private string stoveTriggerName = "stove_trigger";
    private bool onStove = false;
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private AudioSource panHeatingAudio;
    
    void Update()
    {
        if(onStove)
        {
            float dt = Time.deltaTime;
            foreach(Transform childTrans in foodParent.transform)
            {
                var food = childTrans.gameObject;
                var cookedState = food.GetComponent<FoodCookedState>();
                if (cookedState != null)
                {
                    cookedState.IncreaseTimeCooked(dt);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals(stoveTriggerName))
        {
            onStove = true;
            smoke.Play();
            panHeatingAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name.Equals(stoveTriggerName))
        {
            onStove = false;
            smoke.Stop();
            panHeatingAudio.Stop();
        }
    }
}