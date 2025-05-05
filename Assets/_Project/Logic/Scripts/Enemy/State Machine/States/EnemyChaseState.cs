using UnityEngine;

public class EnemyChaseState : EnemyState
{


    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
       
    }

    public override void OnEnter()
    {
        base.OnEnter();

        enemy.EnemyChaseBaseInstance.DoEnterLogic();
    }

    public override void OnExit()
    {
        base.OnExit();

        enemy.EnemyChaseBaseInstance.DoExitLogic();
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        enemy.EnemyChaseBaseInstance.DoFixedUpdateLogic();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        enemy.EnemyChaseBaseInstance.DoUpdateLogic();
    }

    public override void OnAnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.OnAnimationTriggerEvent(triggerType);

        enemy.EnemyChaseBaseInstance.DoAnimationTriggerEventLogic(triggerType);
    }
}
