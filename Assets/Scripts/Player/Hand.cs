using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    private Animator animator;
    private SkinnedMeshRenderer mesh;
    private float gripTarget;

    private float triggerTarget;
    private float gripCurrent;
    private float triggerCurrent;
    [SerializeField] private float speed = 0.05f;

    private string animatorGripParam = "Grip";
    private string animatorTriggerParam = "Trigger";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();    
    }

    public void SetGrip(float readValue)
    {
        gripTarget = readValue;
    }

    public void SetTrigger(float readValue)
    {
        triggerTarget = readValue;
    }

    void AnimateHand()
    {
        if (gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }
        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerParam, triggerCurrent);
        }
    }

    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;
    }
}
