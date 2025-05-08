using UnityEngine;

public class EnemyAttackSOBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.enemy = enemy;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }

    public virtual void DoExitLogic() { }

    public virtual void DoUpdateLogic() 
    {
        if (!enemy.IsWithinAttackDistance)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }
    }

    public virtual void DoFixedUpdateLogic() { }

    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType) { }
}
