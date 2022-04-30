using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Ingredient
{
    public string name = "INGREDIENT NAME";
    public int quantity = 1;
    public string plateIdentifier;
}

[System.Serializable]
public class Task
{
    public string name = "INSERT NAME HERE";
    public List<Ingredient> ingredients = new List<Ingredient>();
    public int timeRemaining = 999;
    public bool isCompleted = false;
}

namespace UI
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private Transform _dishPanel1;
        [SerializeField] private Transform _dishPanel2;
        public GameObject origin;
        public GameObject nlCanvas;
        public GameObject blackScreen;
        public List<Task> tasks = new List<Task>();
        private TextMeshProUGUI panel1DishName;
        private List<TextMeshProUGUI> panel1IngredientTexts = new List<TextMeshProUGUI>();
        private TextMeshProUGUI panel2DishName;
        List<TextMeshProUGUI> panel2IngredientTexts = new List<TextMeshProUGUI>();
        private bool chefTasksComplete = false;
        private bool fadeToBlack = false;

        void Start()
        {
            _dishPanel1.gameObject.SetActive(false);
            _dishPanel2.gameObject.SetActive(false);
            if (tasks.Count > 0)
            {
                _dishPanel1.gameObject.SetActive(true);
                // Get references & update values of task board texts
                panel1DishName = _dishPanel1.GetChild(0).GetComponent<TextMeshProUGUI>();
                panel1DishName.text = tasks[0].name;


                for (int i = 0; i < tasks[0].ingredients.Count; i++)
                {
                    
                    // Ingredients children start at index position 2
                    panel1IngredientTexts.Add(_dishPanel1.GetChild(2 + i).GetComponent<TextMeshProUGUI>());
                    panel1IngredientTexts[i].text =  tasks[0].ingredients[i].quantity+ " " + tasks[0].ingredients[i].name;
                }

                TextMeshProUGUI panel1TimeRemaining = _dishPanel1.GetChild(9).GetComponent<TextMeshProUGUI>();
                panel1TimeRemaining.text = tasks[0].timeRemaining.ToString();

                if (tasks.Count == 2)
                {
                    _dishPanel2.gameObject.SetActive(true);
                    // Get references & update values of task board texts
                    panel2DishName = _dishPanel2.GetChild(0).GetComponent<TextMeshProUGUI>();
                    panel2DishName.text = tasks[1].name;


                    for (int i = 0; i < tasks[1].ingredients.Count; i++)
                    {
                        // Ingredients children start at index position 2
                        panel2IngredientTexts.Add(_dishPanel2.GetChild(2 + i).GetComponent<TextMeshProUGUI>());
                        panel2IngredientTexts[i].text = tasks[1].ingredients[i].quantity + " " + tasks[1].ingredients[i].name;
                    }

                    TextMeshProUGUI panel2TimeRemaining = _dishPanel2.GetChild(9).GetComponent<TextMeshProUGUI>();
                    panel2TimeRemaining.text = tasks[1].timeRemaining.ToString();
                }
            }
        }

        void Update()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                // Strikethrough task on blackboard if it is complete
                if (tasks[i].isCompleted)
                {
                    List<TextMeshProUGUI> textToStrikeThrough =
                        new List<TextMeshProUGUI>(i == 0 ? panel1IngredientTexts : panel2IngredientTexts);
                    textToStrikeThrough.Add(i == 0 ? panel1DishName : panel2DishName);
                    for (int j = 0; j < textToStrikeThrough.Count; j++)
                    {
                        textToStrikeThrough[j].fontStyle = FontStyles.Strikethrough;
                    }
                }
            }

            //If the player has completed all the tasks for the first time,
            //we move them far away and active the next level canvas.
            if (tasks.Count > 0 && !chefTasksComplete) {
                bool allTasksComplete = true;
                foreach (Task t in tasks) {
                    if (!t.isCompleted) {
                        allTasksComplete = false;
                    }
                }

                if (allTasksComplete) {
                    chefTasksComplete = true;
                    fadeToBlack = true;
                }
            }

            if (fadeToBlack) {
                print(blackScreen.GetComponent<RawImage>().color.a);
                if (blackScreen.GetComponent<RawImage>().color.a <= 1) {
                    Color objectColor = blackScreen.GetComponent<RawImage>().color;
                    float fadeAmount = objectColor.a + (0.5f * Time.deltaTime);
                    blackScreen.GetComponent<RawImage>().color = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                } else {
                    fadeToBlack = false;
                    Color objectColor = blackScreen.GetComponent<RawImage>().color;
                    blackScreen.GetComponent<RawImage>().color = new Color(objectColor.r, objectColor.g, objectColor.b, 0f);
                    origin.transform.position = new Vector3(100f, 100f, 100f);
                    nlCanvas.SetActive(true);
                }
            }
        }
    }
}