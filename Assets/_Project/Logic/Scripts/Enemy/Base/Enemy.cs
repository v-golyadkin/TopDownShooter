using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IMoveable, ITriggerCheckable
{
    [field: SerializeField] public int MaxHealth { get; set; } = 3;
    public int CurrentHealth { get; set; }
    public Rigidbody2D Rigidbody { get; set; }
    public float MoveSpeed { get; set; }
    public bool IsFacingRight { get; set; } = true;

    public event Action OnDeath;

    public EnemyStateMachine StateMachine { get; private set; }
    
    public EnemyIdleState IdleState { get; private set; }

    public EnemyChaseState ChaseState { get; private set; }

    public EnemyAttackState AttackState { get; private set; }

    public bool IsAggroed { get; set; }
    public bool IsWithinAttackDistance { get; set; }

    #region Idle Variables

    #endregion

    #region ScriptableObject Variables

    [SerializeField] private EnemyIdleSOBase EnemyIdleBase;
    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;

    public EnemyIdleSOBase EnemyIdleBaseInstance { get; set; }
    public EnemyChaseSOBase EnemyChaseBaseInstance { get; set; }

    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }
    #endregion

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

        InitializeStates();
    }

   

    private void Start()
    {
        CurrentHealth = MaxHealth;

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.OnUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.OnFixedUpdate();
    }

    private void InitializeStates()
    {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);

        EnemyIdleBaseInstance = Instantiate(EnemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);

        EnemyIdleBaseInstance.Initialize(gameObject, this);
        EnemyChaseBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);
    }

    #region Damage System

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

    #endregion

    #region Movement System
    public void MoveTo(Vector2 velocity)
    {
        Rigidbody.linearVelocity = velocity;

        AdjustFacingDirection(velocity);
    }

    public void AdjustFacingDirection(Vector2 velocity)
    {
        if(IsFacingRight && velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            IsFacingRight = false;
        }
        else if(!IsFacingRight && velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            IsFacingRight = true;
        }
    }

    #endregion

    #region Animation Triggers

    public enum AnimationTriggerType
    {
        EnemyDamaged
    }

    private void OnAnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.OnAnimationTriggerEvent(triggerType);
    }

    #endregion

    #region Distance Checks

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetWithinAttackDistance(bool isWithinAttackDistance)
    {
        IsWithinAttackDistance = isWithinAttackDistance;
    }

    #endregion
}
