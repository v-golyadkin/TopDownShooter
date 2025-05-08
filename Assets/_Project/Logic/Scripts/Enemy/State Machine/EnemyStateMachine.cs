using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentEnemyState { get; private set; } 

    public void Initialize(EnemyState startingState)
    {
        CurrentEnemyState = startingState;
        CurrentEnemyState.OnEnter();
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentEnemyState.OnExit();
        CurrentEnemyState = newState;
        CurrentEnemyState.OnEnter();
    }
}
