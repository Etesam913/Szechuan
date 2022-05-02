using System.Collections.Generic;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    private bool doorOpen = false;

    [SerializeField] private Vector3 CLOSED_ANGLES;
    [SerializeField] private Vector3 OPEN_ANGLES;

    [SerializeField] private AudioSource openDoorAudio;    
    [SerializeField] private float openDoorAudioStartFrame = 0;   

    [SerializeField] private AudioSource closeDoorAudio;
    [SerializeField] private float closeDoorAudioStartFrame = 35;    

    [SerializeField] private int interpolationFramesCount = 50;
    private int elapsedFrames;

    public Transform doorAxis;
    // Start is called before the first frame update
    void Start()
    {
        elapsedFrames = interpolationFramesCount + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) ToggleDoor();

        if(elapsedFrames == closeDoorAudioStartFrame && !doorOpen)
            closeDoorAudio.Play();
        else if(elapsedFrames == openDoorAudioStartFrame && doorOpen)
            openDoorAudio.Play();

        if(elapsedFrames <= interpolationFramesCount)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

            doorAxis.localEulerAngles = doorOpen ? Vector3.Lerp(CLOSED_ANGLES, OPEN_ANGLES,   interpolationRatio) : 
                                              Vector3.Lerp(OPEN_ANGLES,   CLOSED_ANGLES, interpolationRatio);

            elapsedFrames++;
        }
    }

    public void ToggleDoor()
    {
        if(elapsedFrames > interpolationFramesCount)
        {
            elapsedFrames = 0;
            doorOpen = !doorOpen;
        }
    }
}
