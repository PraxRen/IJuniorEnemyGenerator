using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
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
            SpawnPoint spawnPoint = GetPandomPointSpawn();
            CreateEnemy(spawnPoint);
            yield return delay;
        }
    }

    private void CreateEnemy(SpawnPoint spawnPoint)
    {
        Enemy enemy = Instantiate(spawnPoint.PrefabEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
        enemy.SetTarget(spawnPoint.Target);
    }

    private SpawnPoint GetPandomPointSpawn()
    {
        int indexRandom = Random.Range(0, _spawnPoints.Length);
        return _spawnPoints[indexRandom];
    }
}