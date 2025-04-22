using System.Collections;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private Transform _arrowSpawnPoint;

    [SerializeField] private float _attackSpeed = 1f;

    private bool _canAttack = true;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            Attack();
    }

    private void Attack()
    {
        if (_canAttack)
        {
            Instantiate(_arrowPrefab, _arrowSpawnPoint.position, transform.parent.rotation);
            _canAttack = false;
            StartCoroutine(CooldownRoutine());
        }
        else
        {
            return;
        }
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(_attackSpeed);
        _canAttack = true;
    }
}
