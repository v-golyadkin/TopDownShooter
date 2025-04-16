using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour, IControllable
{
    [SerializeField] private float _characterSpeed;

    private Rigidbody2D _rb;

    private Vector2 _velocity;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveInternal();
    }

    public void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }

    private void MoveInternal()
    {
        var targetVelocity = _moveDirection * _characterSpeed;

        _velocity = Vector2.Lerp(_velocity, targetVelocity, _characterSpeed * Time.fixedDeltaTime);

        _rb.velocity = _velocity;
    }
}
