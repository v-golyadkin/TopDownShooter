using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameState CurrentGameState { get; private set; }

    public void Initialize(GameState startingState)
    {
        CurrentGameState = startingState;
        CurrentGameState.OnEnter();
    }

    public void ChangeState(GameState newState)
    {
        CurrentGameState.OnExit();
        CurrentGameState = newState;
        CurrentGameState.OnEnter();
    }
}
