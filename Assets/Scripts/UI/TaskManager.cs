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
        public List<Task> tasks = new List<Task>();
        private TextMeshProUGUI panel1DishName;
        private List<TextMeshProUGUI> panel1IngredientTexts = new List<TextMeshProUGUI>();
        private TextMeshProUGUI panel2DishName;
        List<TextMeshProUGUI> panel2IngredientTexts = new List<TextMeshProUGUI>();
        private bool secondTaskAdded = false;
        public bool chefTasksComplete = false;

        public GameObject waiterWrapper;
        private WaiterPathLogic myWaiterPathLogic;

        void Start()
        {
            myWaiterPathLogic = waiterWrapper.GetComponent<WaiterPathLogic>();

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

            /*
            If the first task is completed, we set the waiter
            stage in motion, and add the second task to the
            blackboard. If that task finishes, we set all chef
            tasks to complete, and the next level script is told
            that the game is over since chefTasksComplete = true.
            */
            if (tasks.Count > 0 && !chefTasksComplete) {
                bool allTasksComplete = true;
                foreach (Task t in tasks) {
                    if (!t.isCompleted) {
                        allTasksComplete = false;
                    }
                }

                if (allTasksComplete && tasks.Count == 2) {
                    chefTasksComplete = true;
                }

                if (allTasksComplete) {
                    myWaiterPathLogic.chooseNewTable();
                    if (!secondTaskAdded) {
                        addSecondTask();
                        secondTaskAdded = true;
                    }
                }
            }
        }

        /*
        This appends a second task to the blackboard.
        */
        void addSecondTask() {
            print("TASK: " + tasks[0]);
            Task t2 = new Task();
            t2.name = "Sauteed Vegetables";
            Ingredient i1 = new Ingredient();
            i1.name = "Carrots";
            i1.quantity = 2;
            i1.plateIdentifier = "sliced_carrot";
            Ingredient i2 = new Ingredient();
            i2.name = "Onion";
            i2.quantity = 1;
            i2.plateIdentifier = "sliced_onions";
            Ingredient i3 = new Ingredient();
            i3.name = "Bell Pepper";
            i3.quantity = 1;
            i3.plateIdentifier = "sliced_bell_pepper";
            t2.ingredients.Add(i1);
            t2.ingredients.Add(i2);
            t2.ingredients.Add(i3);
            t2.timeRemaining = 35;
            t2.isCompleted = false;
            tasks.Add(t2);

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
}