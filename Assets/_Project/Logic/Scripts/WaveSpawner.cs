using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [Serializable] public class Wave
    {
        public string waveName;
        public List<SpawnData> enemies;      
    }

    [Serializable] public class SpawnData
    {
        public GameObject prefab;
        public Transform spawnPoint;
    }

    [SerializeField] private List<Wave> _waves;
    [SerializeField][Space] private float _delayBetweenWaves = 1f;

    public event Action OnWaveComplete;

    private int _currentWaveIndex = 0;
    private List<GameObject> _aliveEnemies = new List<GameObject>();

    private void Start()
    {
        Debug.Log($"{_waves.Count} waves");

        //if(_aliveEnemies.Count == 0 && _currentWaveIndex < _waves.Count)
        //{
        //    StartNextWave();
        //}     
    }

    public void StartNextWave()
    {
        if(_currentWaveIndex >= _waves.Count)
        {
            Debug.Log("Все волны пройдены");
            return;
        }

        var currentWave = _waves[_currentWaveIndex];

        StartCoroutine(SpawnWave(currentWave));

        _currentWaveIndex++;
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log($"{_currentWaveIndex + 1} wave");

        SpawnEnemy(wave);

        yield return new WaitUntil(() => _aliveEnemies.Count == 0);

        OnWaveComplete?.Invoke();

        //StartCoroutine(StartNextWaveWithDelay());
    }

    private void SpawnEnemy(Wave wave)
    {
        foreach (var enemySpawnData in wave.enemies)
        {
            var enemy = Instantiate(enemySpawnData.prefab, enemySpawnData.spawnPoint.position, enemySpawnData.spawnPoint.rotation);

            _aliveEnemies.Add(enemy);

            enemy.GetComponent<Enemy>().OnDeath += () => OnEnemyDeath(enemy);
        }
    }

    private void OnEnemyDeath(GameObject enemy)
    {
        _aliveEnemies.Remove(enemy);

        //CheckWaveEnd();
    }

    private void CheckWaveEnd()
    {
        if(_aliveEnemies.Count == 0)
        {
            StartCoroutine(StartNextWaveWithDelay());
        }
    }

    private IEnumerator StartNextWaveWithDelay()
    {
        yield return new WaitForSeconds(_delayBetweenWaves);

        StartNextWave();
    }
}
