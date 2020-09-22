using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 按键顺序为左左右左右左
/// </summary>
public class ProjectPuzzle : MonoBehaviour
{
    private SpriteRenderer _currentSprite;
    private bool _isPuzzling;
    public GameObject book;
    // Start is called before the first frame update

    public bool IsPuzzling
    {
        get { return _isPuzzling;}
        set { _isPuzzling = value;}
    }
    void Start()
    {   
        _currentSprite = GameObject.Find("DisplayImage").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentSprite == null)
            _currentSprite = GameObject.Find("DisplayImage").GetComponent<SpriteRenderer>();

        if(_currentSprite.sprite.name == "project1" && (Input.GetKeyDown("left")))
            _currentSprite.sprite = Resources.Load<Sprite>("Sprites/meeting/project2");
        else if(_currentSprite.sprite.name == "project2" && (Input.GetKeyDown("left")))
            _currentSprite.sprite = Resources.Load<Sprite>("Sprites/meeting/project3");
        else if(_currentSprite.sprite.name == "project3" && (Input.GetKeyDown("right")))
            _currentSprite.sprite = Resources.Load<Sprite>("Sprites/meeting/project4");
        else if(_currentSprite.sprite.name == "project4" && (Input.GetKeyDown("left")))
            _currentSprite.sprite = Resources.Load<Sprite>("Sprites/meeting/project5");
        else if(_currentSprite.sprite.name == "project5" && (Input.GetKeyDown("right")))
            _currentSprite.sprite = Resources.Load<Sprite>("Sprites/meeting/project6");
        else if(_currentSprite.sprite.name == "project6" && (Input.GetKeyDown("left")))
        {
            Debug.Log("Bingo");
            GameObject.Find("UI").GetComponent<ButtonHandler>().ReturnClick();
            if(book != null)
                book.SetActive(true);
        }
        else if(Input.GetKeyDown("left") || Input.GetKeyDown("right"))
        {
            _currentSprite.sprite = Resources.Load<Sprite>("Sprites/meeting/project1");
        }
    }
}
