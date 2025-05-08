using UnityEngine;

public class PreWaveState : GameState
{
    private float _preparTime = 2f;
    private float _timer;

    public PreWaveState(GameStateController gameStateController, GameStateMachine gameStateMachine) : base(gameStateController, gameStateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();

        _timer = _preparTime;

        Debug.Log("PreWaveState");
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _timer -= Time.deltaTime;

        if( _timer < 0)
        {
            gameStateMachine.ChangeState(gameStateController.WaveState);
        }
    }
}
