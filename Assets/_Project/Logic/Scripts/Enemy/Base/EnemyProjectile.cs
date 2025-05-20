using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;

    private Vector3 _target;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_target.normalized *  _projectileSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            return;
        }

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable);

            damageable.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
