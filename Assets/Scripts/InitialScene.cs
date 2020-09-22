using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// To intial objects will not be destoryed in the first Scene
/// </summary>
public class InitialScene : MonoBehaviour
{   
    // Start is called before the first frame update
    void Awake()
    {
        var allGos = FindObjectsOfType<GameObject>();
        foreach(var obj in allGos)
        {
            if (obj.tag != "MainCamera") 
                DontDestroyOnLoad(obj);
        }
        SceneManager.LoadScene(2);
    }
}
