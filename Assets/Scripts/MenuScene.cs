using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject helpPanel;
    void Start()
    {
        
    }

    public void StartOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void HelpOnClick()
    {
        helpPanel.SetActive(true);
    }

    public void CloseHelpOnClick()
    {
        helpPanel.SetActive(false);
    }
}
