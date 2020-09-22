using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZoomIn : MonoBehaviour
{
    public float ZoomRatio = .5f;
    public string dialog;

    public void Interact(DisplayImage currentDisplay)
    {
        Camera.main.orthographicSize *= ZoomRatio;
        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
            Camera.main.transform.position.z);
        currentDisplay.CurrentState = DisplayImage.State.zoom;
        var interobj = GameObject.FindGameObjectsWithTag("Interactable");
        foreach(var obj in interobj)
            obj.layer = 2; //layer:2.Ignore Raycast     
    }

//
    void ConstrainCamera()
    {
        var height = Camera.main.orthographicSize;
        var width = height * Camera.main.aspect;
    }
}
