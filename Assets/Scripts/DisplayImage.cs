using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameObject DisplayImage 
/// </summary>
public class DisplayImage : MonoBehaviour
{
    private string _currentWallName;
    public enum State
    {
        normal,
        zoom,
        changeView
    };

    private State _currentState;

    public State CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public string CurrentWallName
    {
        get { return _currentWallName; }
    }

    void Awake() {
        _currentState = State.normal;
        _currentWallName = this.GetComponent<SpriteRenderer>().sprite.name;
    }
}
