using UnityEngine;

[CreateAssetMenu(fileName = "Chase-Direct Chase", menuName = "Enemy Logic/Chase Logic/Direct Chase")]
public class EnemyChaseDirectToPlayer : EnemyChaseSOBase
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

        Debug.Log("Chase State");
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFixedUpdateLogic()
    {
        base.DoFixedUpdateLogic();

        var direction = (playerTransform.position - enemy.transform.position).normalized;

        enemy.MoveTo(direction * _moveSpeed);
    }

    public override void DoUpdateLogic()
    {
        base.DoUpdateLogic();
    }
}
