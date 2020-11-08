using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickSFX : MonoBehaviour
{
    public static MouseClickSFX instance = null;

    public Texture2D mouseUpTexture;
    public Texture2D mouseDownTexture;

    Vector2 hotspot = new Vector2(50f, 50f);

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(mouseDownTexture, hotspot, CursorMode.Auto);

            if (GlobalVars.toggleSfx)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(mouseUpTexture, hotspot, CursorMode.Auto);
        }
    }
}
