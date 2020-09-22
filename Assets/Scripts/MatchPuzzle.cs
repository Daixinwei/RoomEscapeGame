using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchPuzzle : MonoBehaviour
{
    public MatchBox[] matchBoxs;
    public string[] answerCode;
    public bool isEndPuzzle;
    public GameObject jumpObj;

    // Update is called once per frame
    void Update()
    {   
        CheckAnswer();
    }

    private void CheckAnswer()
    {
        for(int i = 0; i < matchBoxs.Length; i++)
        {
            if(matchBoxs[i].gameObject.GetComponent<SpriteRenderer>().sprite.name != answerCode[i])
            {
                return;
            }
        }

        Debug.Log("Bingo");
        GameObject.Find("UI").GetComponent<ButtonHandler>().ReturnClick();
        if(jumpObj != null)
        {
            jumpObj.SetActive(true);
        }
        else if(isEndPuzzle)
        {
               SceneManager.LoadScene(5);
        }
    }
}
