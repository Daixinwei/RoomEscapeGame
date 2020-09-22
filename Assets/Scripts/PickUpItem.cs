using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public string displayItemName;
    public string description;
    public Property property;
    public bool isChangeView;
    public string changeToSpriteName;
    public GameObject parentObject;
    public string dialog;
    private Transform[] _inventorySlots;

    void Awake()
    {
    }
    void Start()
    {
        _inventorySlots = GameObject.Find("Inventory").GetComponent<Inventory>().slots;
        
    }

    public void Interact(DisplayImage currentDisplay)
    {
        ItemPickUp();
        if(isChangeView)
        {  
            currentDisplay.gameObject.GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("Sprites/"+ changeToSpriteName);   

            var view = parentObject.GetComponent<ChangeView>();
            if(view)
            {
                view.SpriteName = this.changeToSpriteName;
            }    
        }
    }

    private void ItemPickUp()
    {
        foreach(Transform slot in _inventorySlots)
        {
            if(slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite =
                    Resources.Load<Sprite>("SpriteS/Objects/" + displayItemName);
                //Set property of item belong to this slot 
                slot.GetComponent<Slot>().Assign((int)property, displayItemName, description);
                //消除可拾取物品自身（该脚本控制的物体）
                Destroy(this.gameObject);
                //跳出循环
                break;
            }
        }
    }
}

/// <summary>
/// Define that whether this item usable or displayable.
/// </summary>
public enum Property
{
    usable,
    displayable
};