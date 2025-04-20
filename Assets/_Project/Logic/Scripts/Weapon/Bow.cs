using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private GameObject _arrowPrefab;
    [SerializeField] private Transform _arrowSpawnPoint;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Attack();
    }

    private void Attack()
    {
        Instantiate(_arrowPrefab, _arrowSpawnPoint.position, transform.parent.rotation);
    }
}
