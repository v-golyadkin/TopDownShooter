using UnityEngine;

public interface ITriggerCheckable
{
    public bool IsAggroed { get; set; }

    public bool IsWithinAttackDistance { get; set; }

    public void SetAggroStatus(bool isAggroed);

    public void SetWithinAttackDistance(bool isWithinAttackDistance);
}
