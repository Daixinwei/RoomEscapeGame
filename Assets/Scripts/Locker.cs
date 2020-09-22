using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    public string unlockItemName;
    public string changeToSpriteName;
    public GameObject parentObject;
    public string dialog = "需要某样道具才能打开";
    private Inventory _inventory;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void Interact(DisplayImage currentDisplay)
    {
        if(_inventory.CurrentSelectedSlot)
        {
            if(_inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite.name 
                == unlockItemName)
            {   
                Debug.Log("Unlock");
                dialog = "操作成功";
                //从物品栏丢掉使用的解锁用物品（需要改进）
                _inventory.CurrentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite
                     = Resources.Load<Sprite>("Sprites/Objects/empty_item");
                //解锁后变换背景的图片
                currentDisplay.gameObject.GetComponent<SpriteRenderer>().sprite =
                    Resources.Load<Sprite>("Sprites/"+ changeToSpriteName);  

                var view = parentObject.GetComponent<ChangeView>();
                if(view)
                {
                    view.SpriteName = this.changeToSpriteName;
                }     

                var interobj = GameObject.FindGameObjectsWithTag("Interactable");
                foreach(var obj in interobj)
                    obj.layer = 2; //layer:2.Ignore Raycast       
            }
        }
    }
}
