using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{   public Transform[] slots;
    public GameObject itemDisplayer;
    public GameObject CurrentSelectedSlot{ get; set;}
    public GameObject PreviousSelectedSlot{ get; set;}

    // Start is called before the first frame update
    void Start()
    {
        itemDisplayer.SetActive(false);
    }
    
    void Update() {
        SelectedSlot();
    }
    private void SelectedSlot()
    {
        foreach(Transform slot in slots)
        {
            if(slot.gameObject == CurrentSelectedSlot 
                //&& slot.GetComponent<Slot>().ItemProperty == Property.usable 
                && slot.GetChild(0).GetComponent<Image>().sprite.name != "empty_item")
            {
                slot.GetComponent<Image>().color = new Color(.5f, .5f, .5f, 1);
            }
            else
            {
                slot.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }
}
