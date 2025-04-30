using System;

public interface IDamageable 
{
    public event Action OnDeath;
    public int MaxHealth { get; set; }

    public int CurrentHealth { get; set; }

    public void TakeDamage(int damageAmount);

    public void Die();
}
