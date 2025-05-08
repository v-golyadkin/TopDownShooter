using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IDamageable, IControllable
{
    [SerializeField] private float _characterSpeed;

    [field: SerializeField] public int MaxHealth { get; set; } = 3;

    private Rigidbody2D _rb;
    
    private Vector2 _velocity;
    private Vector2 _moveDirection;

    private bool _canTakeDamage = true;

    public event Action OnDeath;

    public int CurrentHealth { get; set; }
    public Rigidbody2D Rigidbody { get ; set; }
    public bool IsFacingRight { get; set; }

    private Animator _animator;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        MoveInternal();
    }

    public void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }

    private void MoveInternal()
    {
        _velocity = _moveDirection * _characterSpeed;

        Rigidbody.linearVelocity = _velocity;

        if (_velocity != Vector2.zero)
        {
            _animator.SetTrigger("Move");
        }
        else
        {
            _animator.SetTrigger("Idle");
        }
    }

    private void AdjustPlayerFacingDirection()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePosition.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }


    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(2f);
        _canTakeDamage = true;
    }

    public void TakeDamage(int damageAmount)
    {
        if (!_canTakeDamage) { return; }

        _canTakeDamage = false;

        CurrentHealth -= damageAmount;

        Debug.Log(CurrentHealth);

        if(CurrentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(DamageRecoveryRoutine());
    }

    public void Die()
    {
        Debug.Log("Player died");

        OnDeath?.Invoke();
        //todo
    }

    public void MoveTo(Vector2 velocity)
    {
        throw new NotImplementedException();
    }


    public void AdjustFacingDirection(Vector2 velocity)
    {
        throw new NotImplementedException();
    }
}
