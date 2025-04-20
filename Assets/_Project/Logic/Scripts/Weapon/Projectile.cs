using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _projectileSpeed);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        return;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
