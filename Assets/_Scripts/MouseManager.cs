using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;
    
    public Texture2D interactiveTexture;
    public Texture2D defaultTexture;
    private CursorMode _cursorMode = CursorMode.ForceSoftware;
    
    private void Awake()
    {
        var instanceCount = FindObjectsOfType<MouseManager>().Length;
        if (instanceCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void Start()
    {
        SetDefaultCursor();
    }

    private void Update()
    {
        if (MouseOverInteractObj())
        {
            SetInteractCursor();
        }
        else
        {
            SetDefaultCursor();
        }
    }

    public static bool MouseOverInteractObj()
    {
        var raycastResults = GetEventSystemRaycastResults();
        if (raycastResults.Count == 0)
            return false;
        foreach (var result in raycastResults)
        {
            if (result.gameObject.CompareTag("Interactible"))
            {
                return true;
            }
        }
        return false;
    }

    public void SetInteractCursor()
    {
        Cursor.SetCursor(interactiveTexture, Vector2.zero, _cursorMode);
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultTexture, Vector2.zero, _cursorMode);
    }
    
    ///Gets all event systen raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {   
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position =  Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll( eventData, raysastResults );
        return raysastResults;
    }
}
