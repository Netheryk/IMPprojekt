using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootAtCursor : MonoBehaviour
{
    private Vector2 cursorInput;
    public Vector2 CursorInput => cursorInput;

    public Vector2 CursorPosition { get; set; }

    [SerializeField] InputActionReference cursorPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cursorInput = GetCursorInput();
        transform.right = (CursorPosition - (Vector2)transform.position).normalized;
        Debug.Log(Input.mousePosition);
    }

    private Vector2 GetCursorInput()
    {
        Vector3 mousePos = cursorPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
