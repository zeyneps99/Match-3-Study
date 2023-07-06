using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {

    private PlayerInputActions _playerInputActions;

    private Camera _mainCamera;
    private void OnEnable()
    {
        _mainCamera = Camera.main;
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Touch.performed += OnTouch;
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Touch.performed -= OnTouch;

    }

    public void SetCommand(Command command)
    {
        Events.CoreEvents.OnCommand?.Invoke(command);
    }


    public void OnTouch(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = context.ReadValue<Vector2>();
        Entity entity = GetCollisionEntity(touchPosition);
        if (entity != null)
        {
            TouchCommand command = new TouchCommand(entity, touchPosition);
            SetCommand(command);
        }
        
    }

    private Entity GetCollisionEntity(Vector2 position)
    {
        Ray ray = _mainCamera.ScreenPointToRay(position);
        
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out Entity entity))
            {
                return entity;
            }
        }
        return null;
    }


}
