using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 225;

    public Transform origin = null;

    public GameObject streamPrefab = null;

    private bool _isPouring = false;

    private Stream _currentStream = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;
        
        if (_isPouring != pourCheck)
        {
            _isPouring = pourCheck;
            if (_isPouring)
            {
                StartPour();
            }
            else if(_currentStream)
            {
                EndPour();
            }
        }

       
    }
    
    private void StartPour(){
            // Empty
            print("Start");
            _currentStream = CreateStream();
            _currentStream.Begin();
    }

    private void EndPour()
    {
        // Empty
        _currentStream.End();
        _currentStream = null;
        print("End");
    }

    private float CalculatePourAngle()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }

    public Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}
