using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameStateMachine StateMachine { get; private set; }

    public WaveState WaveState { get; private set; }

    public PreWaveState PreWaveState { get; private set; }

    [SerializeField] private WaveSpawner _waveSpawner;

    private void Start()
    {
        StateMachine = new GameStateMachine();

        WaveState = new WaveState(this, StateMachine, _waveSpawner);
        PreWaveState = new PreWaveState(this, StateMachine);

        StateMachine.Initialize(PreWaveState);
    }

    private void Update()
    {
        StateMachine.CurrentGameState.OnUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentGameState.OnFixedUpdate();
    }
}
