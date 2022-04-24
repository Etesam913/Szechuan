using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Task
{
    public string name = "INSERT NAME HERE";

    public List<string> ingredients = new List<string>();

    public int timeRemaining = 999;
}

namespace UI
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private Transform _dishPanel1;
        [SerializeField] private Transform _dishPanel2;
        public List<Task> tasks = new List<Task>();

        void Start()
        {
            _dishPanel1.gameObject.SetActive(false);
            _dishPanel2.gameObject.SetActive(false);
            if (tasks.Count > 0)
            {
                _dishPanel1.gameObject.SetActive(true);
                // Get references & update values of task board texts
                TextMeshProUGUI panel1DishName = _dishPanel1.GetChild(0).GetComponent<TextMeshProUGUI>();
                panel1DishName.text = tasks[0].name;
                
                List<TextMeshProUGUI> panel1IngredientTexts = new List<TextMeshProUGUI>();
                for (int i = 0; i < tasks[0].ingredients.Count; i++)
                {
                    // Ingredients children start at index position 2
                    panel1IngredientTexts.Add(_dishPanel1.GetChild(2+i).GetComponent<TextMeshProUGUI>());
                    panel1IngredientTexts[i].text = tasks[0].ingredients[i];
                }
                
                TextMeshProUGUI panel1TimeRemaining = _dishPanel1.GetChild(9).GetComponent<TextMeshProUGUI>();
                panel1TimeRemaining.text = tasks[0].timeRemaining.ToString();
                
                if (tasks.Count == 2)
                {
                    _dishPanel2.gameObject.SetActive(true);
                    // Get references & update values of task board texts
                    TextMeshProUGUI panel2DishName = _dishPanel2.GetChild(0).GetComponent<TextMeshProUGUI>();
                    panel2DishName.text = tasks[1].name;
                
                    List<TextMeshProUGUI> panel2IngredientTexts = new List<TextMeshProUGUI>();
                    for (int i = 0; i < tasks[1].ingredients.Count; i++)
                    {
                        // Ingredients children start at index position 2
                        panel2IngredientTexts.Add(_dishPanel2.GetChild(2+i).GetComponent<TextMeshProUGUI>());
                        panel2IngredientTexts[i].text = tasks[1].ingredients[i];
                    }
                
                    TextMeshProUGUI panel2TimeRemaining = _dishPanel2.GetChild(9).GetComponent<TextMeshProUGUI>();
                    panel2TimeRemaining.text = tasks[1].timeRemaining.ToString();
                }
            }
            
        }

    }
}