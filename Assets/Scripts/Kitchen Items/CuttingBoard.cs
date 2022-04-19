using TMPro;
using UnityEngine;


namespace Kitchen_Items
{
    public class CuttingBoard : MonoBehaviour
    {
        [SerializeField] private GameObject slicedCarrotPrefab;
        [SerializeField] private GameObject slicedBellPepperPrefab;
        [SerializeField] private GameObject slicedOnionPrefab;
        [SerializeField] private TextMeshProUGUI debugText;
        private string _carrotTag = "Carrot";

        private string _bellPepperTag = "BellPepper";

        private string _onionTag = "Onion";
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_carrotTag))
            {
                // instantiate sliced carrot
                debugText.text = other.transform.parent.name;
                GameObject slicedCarrot1 = Instantiate(slicedCarrotPrefab, transform, false) as GameObject;
                slicedCarrot1.transform.localPosition = new Vector3(0, 5, 0);
                GameObject slicedCarrot2 = Instantiate(slicedCarrotPrefab, transform, false) as GameObject;
                slicedCarrot2.transform.localPosition = new Vector3(0, 5, 0);
                slicedCarrot2.transform.localScale = new Vector3(24, 24, 24);
                
                Destroy(other.transform.parent.gameObject);
            }
            if (other.CompareTag(_bellPepperTag))
            {
                // instantiate sliced bell pepper
                debugText.text = other.transform.parent.name;
                GameObject slicedBellPepper = Instantiate(slicedBellPepperPrefab, transform, false) as GameObject;
                slicedBellPepper.transform.localPosition = new Vector3(3.72f, 5, 0);
                Destroy(other.gameObject);
            }
            if (other.CompareTag(_onionTag))
            {
                // instantiate sliced onion
                debugText.text = other.transform.parent.name;
                GameObject slicedOnions = Instantiate(slicedOnionPrefab, transform, false) as GameObject;
                slicedOnions.transform.localPosition = new Vector3(3.72f, 5, 0);

                Destroy(other.transform.parent.gameObject);
            }
            
        }
    }
}
