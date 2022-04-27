using System.Collections.Generic;
using UnityEngine;


public class OpenCloseFridge : MonoBehaviour
{
    private bool doorOpen = false;

    private Vector3 CLOSED_ANGLES;
    private Vector3 OPEN_ANGLES;

    private int interpolationFramesCount = 35;
    private int elapsedFrames;

    public Transform doorAxis;
    // Start is called before the first frame update
    void Start()
    {
        CLOSED_ANGLES = new Vector3(0.0f,0.0f,0.0f);
        OPEN_ANGLES = new Vector3(0.0f,-90.0f,0.0f);
        elapsedFrames = interpolationFramesCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(elapsedFrames <= interpolationFramesCount)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

            doorAxis.eulerAngles = doorOpen ? Vector3.Lerp(CLOSED_ANGLES, OPEN_ANGLES,   interpolationRatio) : 
                                              Vector3.Lerp(OPEN_ANGLES,   CLOSED_ANGLES, interpolationRatio);

            elapsedFrames++;
        }
    }

    public void ToggleFridgeDoor()
    {
        if(elapsedFrames > interpolationFramesCount)
        {
            elapsedFrames = 0;
            doorOpen = !doorOpen;
        }
    }
}
