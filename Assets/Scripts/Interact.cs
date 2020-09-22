using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Interact : MonoBehaviour
{
    private DisplayImage _currentDisplay;
    private ButtonHandler _buttonhandler;
    private string _dialog;
    public GameObject dialogPanel;
    

    void Awake() {
         if(GameObject.FindGameObjectWithTag("SceneManager").gameObject != this.gameObject) //如果找到一个tag为SceneManager的对象，且不是自己本身
            Destroy(this.gameObject);
        

    }
    // Start is called before the first frame update
    void Start()
    {   
        _currentDisplay = GameObject.Find("DisplayImage").GetComponent<DisplayImage>();
        _buttonhandler = GameObject.FindGameObjectWithTag("UI").GetComponent<ButtonHandler>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            Destroy(this.gameObject);
        };

        if(!_currentDisplay)
        {
            _currentDisplay = GameObject.Find("DisplayImage").GetComponent<DisplayImage>();
        }

        //鼠标左键点击事件
        if(Input.GetMouseButtonDown(0))     
        {   

            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 100);

            //如果没有碰撞
            if(!hit)
            {
                var inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
                if(inventory.CurrentSelectedSlot)
                {
                    inventory.CurrentSelectedSlot = null;
                }

                dialogPanel.SetActive(false);
            }
            
            
            //如果点击到可交互的物体
            if(hit && hit.transform.tag == "Interactable")
            {  
                if(hit.transform.GetComponent<ZoomIn>())
                {
                    hit.transform.GetComponent<ZoomIn>().Interact(_currentDisplay);  
                    _dialog = hit.transform.GetComponent<ZoomIn>().dialog;
                    _buttonhandler.setButtons();
                }  
                else if(hit.transform.GetComponent<ChangeView>())
                { 
                    hit.transform.GetComponent<ChangeView>().Interact(_currentDisplay); 
                    _dialog = hit.transform.GetComponent<ChangeView>().dialog;
                    _buttonhandler.setButtons();

                }
                else if(hit.transform.GetComponent<PickUpItem>())
                { 
                    hit.transform.GetComponent<PickUpItem>().Interact(_currentDisplay); 
                    _dialog = hit.transform.GetComponent<PickUpItem>().dialog;
                }
                else if(hit.transform.GetComponent<Locker>())
                { 
                    hit.transform.GetComponent<Locker>().Interact(_currentDisplay); 
                     _dialog = hit.transform.GetComponent<Locker>().dialog;
                }
                else if(hit.transform.GetComponent<FillCup>())
                { 
                    hit.transform.GetComponent<FillCup>().Interact(); 
                    _dialog = hit.transform.GetComponent<FillCup>().dialog;
                }
                else if(hit.transform.GetComponent<MatchBox>())
                { 
                    hit.transform.GetComponent<MatchBox>().Interact(); 
                    _dialog = hit.transform.GetComponent<MatchBox>().dialog;
                }
                if(_dialog != null)
                {
                    dialogPanel.SetActive(true);
                    dialogPanel.transform.GetChild(0).GetComponent<Text>().text = _dialog;
                    _dialog = null;
                }
                else
                {
                    dialogPanel.SetActive(false);
                }
            }
            
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
