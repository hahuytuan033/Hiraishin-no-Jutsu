using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private Vector2 cursorHotpot;

    // Start is called before the first frame update
    void Start()
    {
        cursorHotpot= new Vector2(cursorTexture.width/2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture, cursorHotpot, CursorMode.Auto);
    }
}
