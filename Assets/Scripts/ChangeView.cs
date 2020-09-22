using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
    public string SpriteName;
    public string dialog;

    // Start is called before the first frame update
    public void Interact(DisplayImage currentDisplay)
    {
        currentDisplay.gameObject.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Sprites/"+ SpriteName);       
        currentDisplay.CurrentState = DisplayImage.State.changeView;

        var interobj = GameObject.FindGameObjectsWithTag("Interactable");
        foreach(var obj in interobj)
            obj.layer = 2; //layer:2.Ignore Raycast     

    }
}
