using UnityEngine;

public class EnemyIdleState : EnemyState
{

    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {

    }

    public override void OnEnter()
    {
        base.OnEnter();

        enemy.EnemyIdleBaseInstance.DoEnterLogic();
    }

    public override void OnExit()
    {
        base.OnExit();

        enemy.EnemyIdleBaseInstance.DoExitLogic();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        enemy.EnemyIdleBaseInstance.DoFixedUpdateLogic();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        enemy.EnemyIdleBaseInstance.DoUpdateLogic();
    }

    public override void OnAnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.OnAnimationTriggerEvent(triggerType);

        enemy.EnemyIdleBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }
}
