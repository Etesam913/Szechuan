using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Tutorial")
        {
            if (Board_Tutorial.boardDone == true && (onStove))
            {
                Stove_Tutorial.stoveDone = true;
            }

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