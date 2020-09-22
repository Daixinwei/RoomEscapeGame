using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsManager : MonoBehaviour
{   
    public GameObject[] Objects;
    private DisplayImage _currentDisplay;
    private string _currentDisplayName;
    private string _previousDisplayName;

    void Awake()
    {
        if(GameObject.Find("ObjectsManager").gameObject != this.gameObject) //如果找到一个名为ObjectsManager的对象，且不是自己本身
            Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        _previousDisplayName = null;
        _currentDisplayName = null;
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

        _currentDisplayName = GameObject.Find("DisplayImage").GetComponent<SpriteRenderer>().sprite.name;
        //将先前场景中有交互标签的物体设置为不可交互
        if(_previousDisplayName != _currentDisplayName)
        {   
            if(_previousDisplayName != null && GameObject.Find(_previousDisplayName))
            {
                var childNum = GameObject.Find(_previousDisplayName).transform.childCount;
                for(var i = 0; i < childNum; i ++)
                {
                    var obj = GameObject.Find(_previousDisplayName).transform.GetChild(i).gameObject;
                    if(obj.tag == "Interactable")
                        obj.layer = 0;
                }               
            }
            _previousDisplayName = _currentDisplayName;
        }

        foreach(var obj in Objects)
        {   
            //如果背景图的名字与该父物体名相同时，激活该父物体
            if(obj.name ==  _currentDisplayName
                || (GameObject.Find("projectInitial") && obj.name == "projectInitial" && _currentDisplay.CurrentState == DisplayImage.State.changeView))
            {
                obj.SetActive(true);
            }   
            else
            {
                obj.SetActive(false);
            }          
        }
    }
}
