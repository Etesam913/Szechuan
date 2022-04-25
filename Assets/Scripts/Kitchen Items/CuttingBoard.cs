using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Kitchen_Items
{
    [Serializable]
    public class CutItemData
    {
        public GameObject slicedPrefab;
        public string foodTag;
        public int quantityToSpawn = 1;
    }

    public class CuttingBoard : MonoBehaviour
    {
        [SerializeField] private List<CutItemData> cutItems = new List<CutItemData>();

        private void OnTriggerEnter(Collider other)
        {
            for (int i = 0; i < cutItems.Count; i++)
            {
                if (other.CompareTag(cutItems[i].foodTag))
                {
                    for (int j = 0; j < cutItems[i].quantityToSpawn; j++)
                    {
                        GameObject slicedItem = Instantiate(cutItems[i].slicedPrefab, transform, false) as GameObject;
                        slicedItem.transform.localPosition = new Vector3(3.72f, 5, 0);
                    }
                    Destroy(other.gameObject);
                }
            }
        }
    }
}