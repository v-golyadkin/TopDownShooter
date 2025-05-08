using UnityEngine;

public class GameState : IState
{
    //protected WaveSpawner waveSpawner; 

    protected GameStateController gameStateController;
    protected GameStateMachine gameStateMachine;
    

    public GameState(GameStateController gameStateController, GameStateMachine gameStateMachine)
    {
        this.gameStateController = gameStateController;
        this.gameStateMachine = gameStateMachine;
    }

    public virtual void OnEnter() { }

    public virtual void OnExit() { }
    public virtual void OnFixedUpdate() { }

    public virtual void OnUpdate() { }
}
