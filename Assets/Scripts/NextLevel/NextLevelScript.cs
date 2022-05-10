using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{

    public GameObject origin;
    public GameObject nlCanvas;
    public GameObject blackScreen;
    public GameObject waiterWrapper;

    public GameObject gameWrapper;
    public GameObject score;

    public GameObject wellDone;
    public GameObject advanceTextObject;

    private WaiterPathLogic myWaiterPathLogic;
    private UI.TaskManager myTaskManager;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI wellDoneText;
    private TextMeshProUGUI advanceText;
    

    // Start is called before the first frame update
    void Start()
    {
        myWaiterPathLogic = waiterWrapper.GetComponent<WaiterPathLogic>();
        myTaskManager = gameWrapper.GetComponent<UI.TaskManager>();

        scoreText = score.GetComponent<TextMeshProUGUI>();
        wellDoneText = wellDone.GetComponent<TextMeshProUGUI>();
        advanceText = advanceTextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //If all chef tasks are complete and we advanced
        //past the waiting stage, game is over!
        if (myTaskManager.chefTasksComplete) {
            wellDoneText.text = "You win!";
            advanceText.text = "Restart";
        }
        
    }

    //We move the player back to the restaurant and set
    //the black canvas to false.
    public void advance() {
        if (myTaskManager.chefTasksComplete) {
            SceneManager.LoadScene("Game");
        }
        origin.transform.position = new Vector3(-1.153372f, -0.9505002f, 41.49769f);
        //origin.transform.eulerAngles = new Vector3(origin.transform.eulerAngles.x, 180f, origin.transform.eulerAngles.z);
        nlCanvas.SetActive(false);
        //myWaiterPathLogic.startWaiterStage();
    }
}
