/******
 * MARCIN'S ASSETS 2019:
 * www.assetstore.unity.com/publishers/6702
******/

using UnityEngine;
using System;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovingWoman : MonoBehaviour
{
    private float moving_speed = 5f;
    private Animator animator;

    public GameObject origin;
    public GameObject plate;
    
    private Vector3 resetPos;
    private Vector3 resetRot;
    private bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = UnityEngine.Random.Range(0.8f, 1.0f);
    }

    /*
    The moving woman's position is taken. If she is close enough to the
    player, a collision is called and an action (currently, a happy dance
    and plate drop) occurs. When that action finishes, the woman
    goes back into her moving cycle.
    The cycle is a square, and she turns 90 degrees on the Y axis after reaching
    a certain X or Z point, such that she perpetually moves in a circle.
    Her speed can be set with the moving_speed variable.
    */
    // Update is called once per frame
    void Update()
    {
        if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("happy_dance") &&
            Math.Abs(origin.transform.position.x - transform.position.x) < 0.6f && Math.Abs(origin.transform.position.z - transform.position.z) < 0.6f) {
            reset = true;
            resetPos = transform.position;
            resetRot = transform.eulerAngles;
            animator.SetTrigger("happy_dance");
            plate.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            plate.gameObject.GetComponent<XRGrabInteractable>().enabled = true;
        } else if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("happy_dance")) {
            
        } else {
            if (reset && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("happy_dance")) {
                transform.position = resetPos;
                transform.eulerAngles = resetRot;
                reset = false;
            }
            transform.Translate(Vector3.forward * Time.deltaTime * moving_speed);
            //transform.Rotate(Vector3.right * Time.deltaTime);
            //(25, -25), 12, 33
            if (transform.position.x < -25) {
                Vector3 newPos = new Vector3(-24.9f, transform.position.y, transform.position.z);
                transform.position = newPos;
                Vector3 newRot = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
                transform.eulerAngles = newRot;
            }
            if (transform.position.x > 25) {
                Vector3 newPos = new Vector3(24.9f, transform.position.y, transform.position.z);
                transform.position = newPos;
                Vector3 newRot = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y + 90, transform.eulerAngles.z);
                transform.eulerAngles = newRot;
            }
            if (transform.position.z < 12) {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 12.1f);
                transform.position = newPos;
                Vector3 newRot = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y + 90, transform.eulerAngles.z);
                transform.eulerAngles = newRot;
            }
            if (transform.position.z > 33) {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, 32.9f);
                transform.position = newPos;
                Vector3 newRot = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y + 90, transform.eulerAngles.z);
                transform.eulerAngles = newRot;
            }
        }

        if (animator)
        {   
        //----WALK----
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                if (animator.GetInteger("move") != 1)
                {
                    animator.SetFloat("speed", 1);
                    animator.SetInteger("move", 1);
                }
            }
            else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                if (animator.GetInteger("move") != 1)
                {
                    animator.SetFloat("speed", -1);
                    animator.SetInteger("move", 1);
                }
            }
        //----RUN-----
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                if (animator.GetInteger("move") != 2)
                    animator.SetInteger("move", 2);
            }
        //----IDLE----
            else
            {
                if (animator.GetInteger("move") != 0)
                {
                    animator.SetInteger("move", 0);
                    animator.SetFloat("speed", 1);
                }
            }
        //---TURN LEFT-----
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -120f * Time.deltaTime);
                if (animator.GetInteger("head_turn") != 1)
                    animator.SetInteger("head_turn", 1);
        //---TURN RIGHT-----
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, 120f * Time.deltaTime);
                if (animator.GetInteger("head_turn") != 2)
                    animator.SetInteger("head_turn", 2);
            }
            else
            {
                if (animator.GetInteger("head_turn") != 0)
                    animator.SetInteger("head_turn", 0);
            }
        //---FORWARD FALL
            if (Input.GetKeyDown(KeyCode.Alpha1) && !animator.GetCurrentAnimatorStateInfo(0).IsName("forward_fall"))
            {
                animator.SetTrigger("forward_fall");
            }
          
        //---BACKWARD FALL
            if (Input.GetKeyDown(KeyCode.Alpha2) && !animator.GetCurrentAnimatorStateInfo(0).IsName("backward_fall"))
            {
                animator.SetTrigger("backward_fall");
            }
        //---SITTING
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                animator.SetTrigger("sitting");
            }
        //---SITTING+hand_up
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                animator.SetTrigger("sitting_hand_up");
            }

        //---HAPPY DANCE
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                animator.SetTrigger("happy_dance");
            }

        //---HAPPY DANCE_2
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                animator.SetTrigger("happy_dance_2");
            }

        //---JUMP
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                animator.SetTrigger("jump");
            }
         //---HANDS ON HEAD
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                animator.SetTrigger("hands_on_head");
            }
         //---HANDS ON HEAD
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                animator.SetTrigger("lying");
            }

         //---HANDS ON HEAD
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                animator.SetTrigger("on_all_fours");
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            //RESET Y position
            if (transform.localPosition.y > -0.95)
                transform.localPosition = Vector3.Slerp(transform.localPosition,
                    new Vector3(transform.localPosition.x, -0.95f, transform.localPosition.z), 0.5f * Time.deltaTime);
        }
    }

}
