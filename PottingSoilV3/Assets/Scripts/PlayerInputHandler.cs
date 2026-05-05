using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private InputActionReference interactAction;

    private void OnEnable()
    {
        interactAction.action.Enable();
        interactAction.action.performed += HandleInteraction;
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
        interactAction.action.performed -= HandleInteraction;
    }

    private void HandleInteraction(InputAction.CallbackContext context)
    {
        if (mainCamera == null) mainCamera = Camera.main;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        if (hit != null)
        {
            if (hit.TryGetComponent(out IClickable clickable))
            {
                clickable.OnClicked();
            }
        }
    }
}