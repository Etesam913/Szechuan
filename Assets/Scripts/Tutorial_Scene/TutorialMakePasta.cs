using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMakePasta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakePasta() {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Game")
        {
            //PlayerPrefs.SetInt("SavedGame", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Tutorial");
        }
        else if (scene.name == "Tutorial") {
            /*SceneManager.LoadScene(PlayerPrefs.GetInt("SavedGame"));*/
            SceneManager.LoadScene("Game");
        }

    }
}
