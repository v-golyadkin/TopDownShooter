using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Shoot-Direct Attack", menuName = "Enemy Logic/Attack Logic/Shoot Direct Attack")]
public class EnemyShootDirectToPlayer : EnemyAttackSOBase
{
    [SerializeField] private GameObject _enemyProjectile;
    [SerializeField] private float _shootColdown = 2f;

    private bool _canShoot = true;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFixedUpdateLogic()
    {
        base.DoFixedUpdateLogic();
    }

    public override void DoUpdateLogic()
    {
        if (_canShoot)
        {
            Shoot();
        }
        else
        {
            return;
        }
        
        base.DoUpdateLogic();
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    private void Shoot()
    {
        Instantiate(_enemyProjectile);
        _canShoot = false;
        ShootColdown();
    }

    private void ShootColdown()
    {
        var timer = 0f;

        while(timer != _shootColdown)
        {
            timer += Time.fixedDeltaTime;
        }

        _canShoot = true;
    }
}
