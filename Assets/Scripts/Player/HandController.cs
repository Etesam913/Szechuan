using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Player
{
    [RequireComponent(typeof(ActionBasedController))]
    public class HandController : MonoBehaviour
    {
        private ActionBasedController controller;
        public Hand hand;
        void Start()
        {
            controller = GetComponent<ActionBasedController>();
        }

        
        void Update()
        {
            hand.SetGrip(controller.selectAction.action.ReadValue<float>());
            hand.SetTrigger(controller.activateAction.action.ReadValue<float>());
        }
    }
}
