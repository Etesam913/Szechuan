using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMakePasta : MonoBehaviour
{
    public GameObject RendererDone;
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
            Stove_Tutorial.stoveDone = false;
            Pan_Tutorial.panDone = false;
            Table_Tutorial.tableDone = false;
            Fridge_Tutorial.fridgeDone = false;
            Knife_Tutorial.knifeDone = false;
            Board_Tutorial.boardDone = false;
            SceneManager.LoadScene("Tutorial");
        }
        else if (scene.name == "Tutorial") {
            /*SceneManager.LoadScene(PlayerPrefs.GetInt("SavedGame"));*/
            RendererDone.GetComponent<MeshRenderer>().enabled = false;
            SceneManager.LoadScene("Game");

        }

    }
}
