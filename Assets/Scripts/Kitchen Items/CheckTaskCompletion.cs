using System.Collections.Generic;
using UI;
using UnityEngine;

public class CheckTaskCompletion : MonoBehaviour
{
    [SerializeField] private TaskManager taskManager;
    
    void Update()
    {
        int childCount = transform.childCount;
        // Checks if a task is completed
        for (int i = 0; i < taskManager.tasks.Count; i++)
        {
            int numOfCorrectIngredients = 0;
            int numOfDesiredCorrectIngredients = 0;
            for (int j = 0; j < taskManager.tasks[i].ingredients.Count; j++)
            {
                Ingredient currentIngredient = taskManager.tasks[i].ingredients[j];
                numOfDesiredCorrectIngredients += currentIngredient.quantity;
                List<int> seenIndices = new List<int>();
                
                // Checks if the quantity of item is correct
                // ex: makes sure there are 2 carrots instead of just one
                for (int q = 0; q < currentIngredient.quantity; q++)
                {
                    for (int k = 0; k < childCount; k++)
                    {
                        if (!seenIndices.Contains(k) && transform.GetChild(k).gameObject.name.Contains(currentIngredient.plateIdentifier))
                        {
                            seenIndices.Add(k);
                            numOfCorrectIngredients += 1;
                        }
                    }    
                }
            }
            
            // The task is complete
            if (numOfCorrectIngredients == numOfDesiredCorrectIngredients)
            {
                taskManager.tasks[i].isCompleted = true;
            }
        }
    }
}
