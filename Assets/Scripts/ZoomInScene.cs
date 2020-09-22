using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInScene : MonoBehaviour
{
    public GameObject SceneObj;
    private DisplayImage _currentDisplay;
    // Update is called once per frame
    void Update()
    {
        if(!_currentDisplay)
        {
            _currentDisplay = GameObject.Find("DisplayImage").GetComponent<DisplayImage>();
        }
        
        if(_currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            SceneObj.SetActive(true);
        }
        else
        {
            SceneObj.SetActive(false);
        }
    }
}
