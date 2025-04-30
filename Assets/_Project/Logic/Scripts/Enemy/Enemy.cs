using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [field: SerializeField] public int MaxHealth { get; set; } = 3;
    public int CurrentHealth { get; set; }

    public event Action OnDeath;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);

        OnDeath?.Invoke();
    }
}
