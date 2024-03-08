using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delaySeconds;

    private Coroutine _jobCreate;

    private void OnDisable()
    {
        if (_jobCreate != null)
            StopCoroutine(_jobCreate); 
    }

    private void Start()
    {
        _jobCreate = StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var delay = new WaitForSeconds(_delaySeconds);

        while (true)
        {
            Transform spawnPoint = GetPandomPointSpawn();
            CreateEnemy(spawnPoint);
            yield return delay;
        }
    }

    private void CreateEnemy(Transform spawnPoint)
    {
        Enemy enemy = Instantiate(_prefabEnemy, spawnPoint.position, spawnPoint.rotation);
        enemy.Movement.Move(spawnPoint.forward);
    }

    private Transform GetPandomPointSpawn()
    {
        int indexRandom = Random.Range(0, _spawnPoints.Length - 1);
        return _spawnPoints[indexRandom];
    }
}