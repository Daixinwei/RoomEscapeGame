using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{   
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject ZoomReturnButton;
    public GameObject closeItemDisplayerButton;
    private int _sceneId;
    private DisplayImage _currentDisplay;
    private float _initialCameraSize;
    private Vector3 _initialCameraPosition;
    
    //Awake is called when the script instance is being loaded.
    void Awake() {
        _sceneId = 2;
        //for edit 
        if(GameObject.FindGameObjectWithTag("UI").gameObject != this.gameObject) //如果找到一个tag为UI的对象，且不是自己本身
            Destroy(this.gameObject);
        

    }
   
    // Start is called before the first frame update
    void Start()
    { 
        _currentDisplay = GameObject.Find("DisplayImage").GetComponent<DisplayImage>();
        _initialCameraSize = Camera.main.orthographicSize;
        _initialCameraPosition =  Camera.main.transform.position;
    }

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
    }
    //note:--和++在变量前面表达式为计算后结果，在变量后面为计算前结果
    ///<summary>
    ///click event function.
    ///Attached to buttons which is for switching scene.
    ///</summary>
    public void NavClick(string dir)
    {  
        switch(dir){
            case "left":
                if(--_sceneId < 2) _sceneId = 4;
                break;
            case "right":
                if(++_sceneId > 4) _sceneId = 2;
                break;
            default:
                break;
        }
            SceneManager.LoadScene(_sceneId);
    } 

    /// <summary>
    /// Click event.
    /// </summary>
    public void ReturnClick()
    {  
        if(_currentDisplay.CurrentState == DisplayImage.State.zoom)
        {
            Camera.main.orthographicSize = _initialCameraSize;
            Camera.main.transform.position = _initialCameraPosition;
        }
        else if(_currentDisplay.CurrentState == DisplayImage.State.changeView)
        {
            _currentDisplay.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprites/Wall/"+ _currentDisplay.CurrentWallName);
        }
        _currentDisplay.CurrentState = DisplayImage.State.normal;
        var interobj = GameObject.FindGameObjectsWithTag("Interactable");
        foreach(var obj in interobj)
            obj.layer = 0; //layer:2.Ignore Raycast 

        ZoomReturnButton.SetActive(false);
        rightButton.SetActive(true);
        leftButton.SetActive(true);
        
    }

    public void setButtons()
    {
        ZoomReturnButton.SetActive(true);
        rightButton.SetActive(false);
        leftButton.SetActive(false);
    }

    public void CloseClick()
    {
        closeItemDisplayerButton.transform.parent.gameObject.SetActive(false); //关闭itemdiplayer
    }
} 
