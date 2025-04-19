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
}
