using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _prefabEnemy;

    public Transform Target => _target;
    public Enemy PrefabEnemy => _prefabEnemy;
}
