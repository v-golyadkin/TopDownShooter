using UnityEngine;

public class WaveState : GameState
{
    protected WaveSpawner waveSpawner;

    public WaveState(GameStateController gameStateController, GameStateMachine gameStateMachine, WaveSpawner waveSpawner) : base(gameStateController, gameStateMachine)
    {
        this.waveSpawner = waveSpawner;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("WaveState");

        waveSpawner.OnWaveComplete += OnWaveComplete;

        waveSpawner.StartNextWave();
    }

    public override void OnExit()
    {
        base.OnExit();

        waveSpawner.OnWaveComplete -= OnWaveComplete;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    private void OnWaveComplete()
    {
        gameStateMachine.ChangeState(gameStateController.PreWaveState);
    }
}
