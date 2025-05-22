using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Random Wander", menuName = "Enemy Logic/Idle Logic/Random Wander")]
public class EnemyIdleRandomWander : EnemyIdleSOBase
{
    [SerializeField] private float _randomMovementRange = 5f;
    [SerializeField] private float _randomMovementSpeed = 1f;

    private Vector3 _targetPosition;
    private Vector3 _direction;

    private float _timeToTarget = 0f;

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();

        //Debug.Log("Idle State");

        _targetPosition = GetRandomPointInCircle();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoUpdateLogic()
    {
        base.DoUpdateLogic();
    }

    public override void DoFixedUpdateLogic()
    {
        base.DoFixedUpdateLogic();

        _direction = (_targetPosition - enemy.transform.position).normalized;

        enemy.MoveTo(_direction * _randomMovementSpeed);

        _timeToTarget += Time.deltaTime;

        if ((enemy.transform.position - _targetPosition).sqrMagnitude < 0.01f || _timeToTarget > 2f)
        {
            _targetPosition = GetRandomPointInCircle();

            _timeToTarget = 0f;
        }
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    private Vector3 GetRandomPointInCircle() => enemy.transform.position + (Vector3)Random.insideUnitCircle * _randomMovementRange;
}
