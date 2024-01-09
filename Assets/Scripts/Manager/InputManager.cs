using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{


    [SerializeField] PlayerInput playerInput;
    [SerializeField] GameInput gameInput;

    public static InputManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        gameInput = new GameInput();

    }

    public Vector2 GetPlayerMovement()
    {
        return gameInput.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return gameInput.Player.Aim.ReadValue<Vector2>();
    }

    public bool InteractPressedThisFrame()
    {
        return gameInput.Player.Interact.triggered;
    }
    private void OnEnable()
    {
        playerInput.ActivateInput();
        gameInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.DeactivateInput();
        gameInput.Disable();
    }

    public GameInput GetInput()
    {
        return gameInput;
    }

    public PlayerInput GetPlayerInput()
    {
        return playerInput;
    }

    public void SwitchCurrentActionMap(string _actionMap, float _time=0)
    {
        StartCoroutine(ChangeActionMap(_actionMap, _time));
    }

    IEnumerator ChangeActionMap(string _actionMap, float _time)
    {
        yield return new WaitForSeconds(_time);
        playerInput.SwitchCurrentActionMap(_actionMap);
    }
}
