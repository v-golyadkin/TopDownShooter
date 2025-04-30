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


    private int _currentWaveIndex = 0;
    private List<GameObject> _aliveEnemies = new List<GameObject>();

    private void Start()
    {
        if(_aliveEnemies.Count == 0 && _currentWaveIndex < _waves.Count)
        {
            StartNextWave();
        }     
    }

    private void StartNextWave()
    {
        if(_currentWaveIndex >= _waves.Count)
        {
            Debug.Log("Все волны пройдены");
            return;
        }

        var currentWave = _waves[_currentWaveIndex];

        SpawnWave(currentWave);

        _currentWaveIndex++;
    }

    private void SpawnWave(Wave wave)
    {
        foreach(var enemySpawnData in wave.enemies)
        {
            var enemy = Instantiate(enemySpawnData.prefab, enemySpawnData.spawnPoint.position, enemySpawnData.spawnPoint.rotation);

            _aliveEnemies.Add(enemy);

            enemy.GetComponent<Enemy>().OnDeath += () => OnEnemyDeath(enemy);
        }
    }

    private void OnEnemyDeath(GameObject enemy)
    {
        _aliveEnemies.Remove(enemy);

        CheckWaveEnd();
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
