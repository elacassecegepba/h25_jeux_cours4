using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager> {
    [SerializeField]
    [Tooltip("Nombre d'ennemis à spawner par seconde")]
    private float _spawnRate = 1;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private Enemy _enemyPrefab;
    private float _timeLeftBeforeSpawn = 0;
    private SpawnPoint[] _spawnPoints;
    private GameObject _player;

    void Start() {
        _spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        // Trouver un objet avec le tag "Player" dans la scène.
        // Notez qu'il est préférable d'utiliser un tag plutôt que de
        // chercher par type, car cela peut être plus coûteux en termes
        // de performance.
        _player = GameObject.FindGameObjectWithTag("Player");
        // _player = FindAnyObjectByType<PlayerController>().gameObject;

        // Si on avait plusieurs joueurs, on pourrait faire comme ça :
        // _players = GameObject.FindGameObjectsWithTag("Player");
        
        _timeLeftBeforeSpawn = 1 / _spawnRate;
    }

    void Update() {
        UpdateSpawn();
    }

    private void UpdateSpawn() {
        _timeLeftBeforeSpawn -= Time.deltaTime;
        if (_timeLeftBeforeSpawn <= 0) {
            SpawnEnemy();
            _timeLeftBeforeSpawn = 1 / _spawnRate;
        }
    }

    private void SpawnEnemy() {
        SpawnPoint spawnPoint = GetRandomSpawnPoint();

        Enemy enemy = Instantiate(
           _enemyPrefab,
           spawnPoint.transform.position,
           Quaternion.LookRotation(_player.transform.position), // Regarde le joueur
           _enemyContainer.transform
        );
    }

    private SpawnPoint GetRandomSpawnPoint() {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }
}