using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    private Texture2D _cursorTexture;
    /// <summary>
    /// Called every frame while the mouse is over the GUIElement or Collider.
    /// </summary>
    void OnMouseOver()
    {   _cursorTexture = Resources.Load<Texture2D>("Texture2D/cursor");
        Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);

    }

    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    void OnMouseExit()
    {
        Cursor.SetCursor(null,Vector2.zero, CursorMode.Auto);
    }
}
