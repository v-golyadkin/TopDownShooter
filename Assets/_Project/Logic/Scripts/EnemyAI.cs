using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    [SerializeField] private float _movespeed = 2f;
    [SerializeField] private float _roamingRadius = 5f;
    [SerializeField] private float _chaseRadius = 10f;

    [SerializeField] private int _health = 3;

    private Transform _player;
    private Vector2 _roamingPosition;
    private Rigidbody2D _rb;

    private Vector2 GetRoamingPosition() => (Vector2)transform.position + Random.insideUnitCircle * _roamingRadius;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _roamingPosition = GetRoamingPosition();
    }

    private void Update()
    {
        var distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if(distanceToPlayer < _chaseRadius)
        {
            Chasing();
        }
        else
        {
            Roaming();
        }
    }

    private void Chasing()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.position, _movespeed * Time.deltaTime);
    }

    private void Roaming()
    {
        transform.position = Vector2.MoveTowards(transform.position, _roamingPosition, _movespeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _roamingPosition) < 0.1f)
        {
            _roamingPosition = GetRoamingPosition();
        }
    }

    public void TakeDamage()
    {
        _health--;
        Debug.Log(_health);
        if(_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
