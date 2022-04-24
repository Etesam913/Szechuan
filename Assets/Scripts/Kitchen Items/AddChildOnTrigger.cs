using UnityEngine;

namespace Kitchen_Items
{
    public class AddChildOnTrigger : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            // Make plate the parent of food when placed in plate
            if (other.gameObject.name.Contains("sliced_onion") || other.gameObject.name.Contains("sliced_carrot") ||
                other.gameObject.name.Contains("sliced_bell_pepper") || other.gameObject.name.Contains("pasta_penne"))
            {
                other.transform.parent = transform;
            }
        }
    }
}
