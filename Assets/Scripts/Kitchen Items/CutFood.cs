using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFood : MonoBehaviour
{
    [Serializable]
    public class CutItemData
    {
        public GameObject slicedPrefab;
        public string foodTag;
        public int quantityToSpawn = 1;
    }
    [SerializeField] private List<CutItemData> cutItems = new List<CutItemData>();

    private bool _detectedCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        Vector3 spawnPoint = collision.contacts[0].point;
        if (!_detectedCollision)
        {
            _detectedCollision = true;
            for (int i = 0; i < cutItems.Count; i++)
            {
                if (other.CompareTag(cutItems[i].foodTag))
                {
                    for (int j = 0; j < cutItems[i].quantityToSpawn; j++)
                    {
                        GameObject slicedItem = Instantiate(cutItems[i].slicedPrefab, transform, false) as GameObject;
                        slicedItem.transform.position = spawnPoint;
                        slicedItem.transform.localScale = new Vector3(50, 50, 50);
                    }
                    Destroy(other.gameObject);
                }
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        _detectedCollision = false;
    }
}
