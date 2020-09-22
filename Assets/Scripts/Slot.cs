using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Inventory _inventory;
    private Property _itemProperty;
    private string _displayItemName;
    private string _description;
    public Property ItemProperty
    {
        get {return _itemProperty;}
    }

    public string DisplayItemName
    {
        get {return _displayItemName;}
    }

    public string Description
    {
        get {return _description;}
    }
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _inventory.PreviousSelectedSlot = _inventory.CurrentSelectedSlot;
        _inventory.CurrentSelectedSlot = this.gameObject;

        //双击显示详细信息
        if(eventData.clickCount == 2 )
        {
            DisplayItem();
        }
    }

    public void Assign(int num, string displayItemName, string descrption)
    {
        _itemProperty = (Property)num;
        _displayItemName = displayItemName;
        _description = descrption;
    }

    public void FillCupAssign(string displayItemName, string descrption)
    {
        _itemProperty = Property.usable;
        _displayItemName = displayItemName;
        _description = descrption;
    }
    private void DisplayItem()
    {
        if(this.transform.GetChild(0).GetComponent<Image>().sprite.name != "empty_item")
        {
            _inventory.itemDisplayer.SetActive(true);
            var itemText = _inventory.itemDisplayer.transform.GetChild(0).gameObject;
            var itemImage = _inventory.itemDisplayer.transform.GetChild(1).gameObject;
            itemText.GetComponent<Text>().text = _description;
            itemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("SpriteS/Objects/" + _displayItemName);
        }
        
    }
}
