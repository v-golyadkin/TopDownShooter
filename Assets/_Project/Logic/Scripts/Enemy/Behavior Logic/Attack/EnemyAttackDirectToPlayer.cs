using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Direct Attack", menuName = "Enemy Logic/Attack Logic/Direct Attack")]
public class EnemyAttackDirectToPlayer : EnemyAttackSOBase
{
    [SerializeField] private float _moveSpeed = 1f;

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        //Debug.Log("Attack State");
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFixedUpdateLogic()
    {
        base.DoFixedUpdateLogic();
        
        var direction = (playerTransform.position - transform.position).normalized;

        enemy.MoveTo(direction * _moveSpeed);
    }

    public override void DoUpdateLogic()
    {
        base.DoUpdateLogic();
    }
}
