using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickHandler : MonoBehaviour
{
    private Camera _mainCamera;
    public PotScreenManager PotScreenManager;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if(!rayHit.collider) return;
        Debug.Log(rayHit.collider.gameObject.name);
        PotScreenManager.click(rayHit.collider.gameObject.name);
    }
}
