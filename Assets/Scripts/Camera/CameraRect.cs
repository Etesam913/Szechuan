using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRect : MonoBehaviour
{
    private Camera cam;
    public Material mat;
    public Material mat2;

    void Start()
    {
        cam = Camera.main;
        //cam.stereoTargetEye = StereoTargetEyeMask.None;
    }

    void Update()
    {
        if (FOVButton.isfov)
        {
            // choose the margin randomly
            /*float margin = Random.Range(0.0f, 0.3f);
            // setup the rectangle
            cam.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);*/
            cam.rect = new Rect(0f, 0.0f, 1f, 1.0f);
            //RenderSettings.skybox = mat2;


        }
        else {
            //RenderSettings.skybox = mat;
        }
    }
}
