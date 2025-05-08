using UnityEngine;

public class EnemyState: IState
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void OnEnter() { }

    public virtual void OnExit() { }

    public virtual void OnFixedUpdate() { }

    public virtual void OnUpdate() { }

    public virtual void OnAnimationTriggerEvent(Enemy.AnimationTriggerType triggerType) { }
}
