using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();

        enemy.EnemyAttackBaseInstance.DoEnterLogic();
    }

    public override void OnExit()
    {
        base.OnExit();

        enemy.EnemyAttackBaseInstance.DoExitLogic();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        enemy.EnemyAttackBaseInstance.DoFixedUpdateLogic();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        enemy.EnemyAttackBaseInstance.DoUpdateLogic();
    }

    public override void OnAnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.OnAnimationTriggerEvent(triggerType);

        enemy.EnemyAttackBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }
}


