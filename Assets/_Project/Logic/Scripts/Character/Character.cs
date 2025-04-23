using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IControllable, IDamageable
{
    [SerializeField] private float _characterSpeed;

    [SerializeField] private int _health = 3;

    private Rigidbody2D _rb;
    
    private Vector2 _velocity;
    private Vector2 _moveDirection;

    private bool _canTakeDamage = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
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

        _rb.velocity = _velocity;
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
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if (!_canTakeDamage) { return; }

        _canTakeDamage = false;

        _health--;

        if(_health <= 0)
        {
            Debug.Log("Death");
        }

        DamageRecoveryRoutine();
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(2f);
        _canTakeDamage = true;
    }
}
