using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        Chasing
    }

    [SerializeField] private float _movespeed = 2f;
    [SerializeField] private float _roamingRadius = 5f;
    [SerializeField] private float _chaseRadius = 10f;

    private State _state;

    private Transform _player;
    private Vector2 _roamingPosition;

    private Vector2 GetRoamingPosition() => (Vector2)transform.position + Random.insideUnitCircle * _roamingRadius;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _roamingPosition = GetRoamingPosition();
    }

    private void Update()
    {
        FindChasingTarget();

        switch (_state)
        {
            default:
            case State.Roaming:
                Roaming();
                break;
            case State.Chasing:
                Chasing();
                break;

        }
    }

    private void Chasing()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _movespeed * Time.deltaTime);
    }

    private void FindChasingTarget()
    {
        if (Vector2.Distance(transform.position, _player.position) < _chaseRadius)
        {
            _state = State.Chasing;
        }
        else 
        {
            _state = State.Roaming;
        }
    }

    private void Roaming()
    {
        transform.position = Vector2.MoveTowards(transform.position, _roamingPosition, _movespeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _roamingPosition) < 0.1f)
        {
            _roamingPosition = GetRoamingPosition();
        }

        //FindChasingTarget();
    }
}
