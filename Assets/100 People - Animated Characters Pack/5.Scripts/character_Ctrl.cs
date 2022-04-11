/******
 * MARCIN'S ASSETS 2019:
 * www.assetstore.unity.com/publishers/6702
******/

using UnityEngine;

public class character_Ctrl : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = Random.Range(0.8f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
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
            if (transform.localPosition.y > 0)
                transform.localPosition = Vector3.Slerp(transform.localPosition,
                    new Vector3(transform.localPosition.x, 0, transform.localPosition.z), 0.5f * Time.deltaTime);
        }
    }
}
