using System.Collections.Generic;
using UnityEngine;

namespace Kitchen_Items
{
    public class AddChildOnTrigger : MonoBehaviour
    {
        private readonly List<string> slicedNames = new List<string>()
        {
            "sliced_onion",
            "sliced_carrot",
            "sliced_bell_pepper",
            "pasta_penne",
            "sliced_mushroom",
            "sliced_garlic"
        };

        void OnTriggerEnter(Collider other)
        {
            // Make plate the parent of food when placed in plate
            if (isOneOfSlicedFoods(other.gameObject.name))
            {
                other.transform.parent = transform;

                // If there is oil, switch its parent to the plate
                // Since oil has no rigidbody it won't be able to enter the trigger by itself.
                foreach (Transform child in other.transform.parent)
                {
                    if (child.gameObject.name.Contains("oil"))
                    {
                        child.parent = transform;
                    }
                }
            }
        }

        bool isOneOfSlicedFoods(string name)
        {
            for (int i = 0; i < slicedNames.Count; i++)
            {
                if (name.Contains(slicedNames[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}