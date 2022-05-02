using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCookingInteractions : MonoBehaviour
{
    public GameObject foodParent;
    static public bool interact = false;
    private string stoveTriggerName = "stove_trigger";
    private bool onStove = false;
    [SerializeField] private ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
                    interact = true;
                }
                else
                {
                    cookedState.NoInteraction();
                    interact = false;
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name.Equals(stoveTriggerName))
        {
            onStove = false;
            smoke.Stop();
        }
    }
}
