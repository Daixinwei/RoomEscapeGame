using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillCup : MonoBehaviour
{
    public string juiceName;
    public string description;
    public string dialog;
    private Inventory _inventory;
    
    void Start()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void Interact()
    {
        if(_inventory.CurrentSelectedSlot)
        {
            if(_inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite.name == "cup"
                || _inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite.name == "cup_app"
                || _inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite.name == "cup_lemon"
                || _inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite.name == "cup_peach")
            {   
                dialog = "已倒取成功";
                _inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite
                     = Resources.Load<Sprite>("Sprites/Objects/cup_" + juiceName);

                _inventory.CurrentSelectedSlot.GetComponent<Slot>().FillCupAssign("cup_" + juiceName, description);
                    
            }
        }
    }
}
