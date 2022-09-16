using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float _xMin;

    float _xMax;

    float _ySpawn;

    int requiredScore = 300;

    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _laserEnemyPrefab;
    [SerializeField] GameObject _asteroidPrefab;
    [SerializeField] GameObject _shieldPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        _xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        _ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;
        InvokeRepeating("SpawnEnemy", 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        int typeDetermine = Random.Range(0,100);

        if (typeDetermine < 70)
        {
            float randXenemy = Random.Range(_xMin, _xMax);
            Instantiate(_enemyPrefab, new Vector3(randXenemy, _ySpawn, 0), Quaternion.identity);
        }
        else if(typeDetermine <85 && typeDetermine>70)
        {
            float randXasteroid = Random.Range(_xMin, _xMax);
            Instantiate(_asteroidPrefab, new Vector3(randXasteroid, _ySpawn, 0), Quaternion.identity);
        }
        else
        {
            float randXufo = Random.Range(_xMin, _xMax);
            Instantiate(_laserEnemyPrefab, new Vector3(randXufo, _ySpawn, 0), Quaternion.identity);
        }
        
        if (GameState.Instance._score >= requiredScore)
        {
            requiredScore =requiredScore * 2;
            float randXshield = Random.Range(_xMin, _xMax);
            Instantiate(_shieldPrefab, new Vector3(randXshield, _ySpawn, 0), Quaternion.identity);
        }
    }
        
        
        

}
