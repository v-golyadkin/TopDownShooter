using System;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    private IControllable _controllable;
    private GameInput _gameInput;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _controllable = GetComponent<IControllable>();

        if(_controllable == null)
        {
            throw new Exception($"The are not IControllable component on the object: {gameObject.name}");
        }
    }

    private void Update()
    {
        ReadMovement();
    }

    private void ReadMovement()
    {
        var inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();

        _controllable.Move(inputDirection);
    }

    private void OnDisable()
    {
        _gameInput.Disable();
    }

}
