using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class MatchBox : MonoBehaviour
{
    public string[] matchableSpriteName;
    public string dialog;
    private string _displayItemName;
    private string _description;
    private Property _itemProperty;
    private Inventory _inventory;
    // Start is called before the first frame update
    void Start() 
    {
       // this.GetComponent<SpriteRenderer>().sprite = null;
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    public void Interact()
    {   
        //如果有物品放置
        if(this.GetComponent<SpriteRenderer>().sprite.name != "empty_item")
        {
            foreach(Transform slot in _inventory.slots)
            {
                if(slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
                {
                    slot.transform.GetChild(0).GetComponent<Image>().sprite =
                        Resources.Load<Sprite>("SpriteS/Objects/" + _displayItemName);
                    //Set property of item belong to this slot 
                    slot.GetComponent<Slot>().Assign((int)_itemProperty, _displayItemName, _description);
                    
                    this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Objects/empty_item");
                    break;
                }
            }
        }

        
        foreach(var curSpriteName in matchableSpriteName)
        {
            if(_inventory.CurrentSelectedSlot)
            {
                if(curSpriteName  == _inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite.name)
                {
                    Debug.Log("Matchable");
                    dialog = "匹配成功";
                    _inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite
                        = Resources.Load<Sprite>("Sprites/Objects/empty_item");
                    _displayItemName = _inventory.CurrentSelectedSlot.GetComponent<Slot>().DisplayItemName;
                    _itemProperty =  _inventory.CurrentSelectedSlot.GetComponent<Slot>().ItemProperty;
                    _description = _inventory.CurrentSelectedSlot.GetComponent<Slot>().Description;

                    _inventory.CurrentSelectedSlot = null;

                    this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Objects/" + curSpriteName);
                    return;
                }
            }
            else
            {
                dialog = "似乎能放入某样东西";
            }
        }
    }
}
