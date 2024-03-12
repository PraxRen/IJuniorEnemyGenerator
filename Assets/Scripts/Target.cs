using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Target : MonoBehaviour
{
    [SerializeField] private PatrolPath _patrolPath;
    [SerializeField] private float _offsetToWaypointPath;
    
    private Movement _movement;
    private int _currentIndexPath;
    private Vector3 _movePosition;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        _movePosition = _patrolPath.GetWaypointPosition(_currentIndexPath);
    }

    private void Update()
    {
        if (Vector3.Distance(_movePosition, transform.position) < _offsetToWaypointPath)
        {
            _patrolPath.SetNextIndex(ref _currentIndexPath);
            _movePosition = _patrolPath.GetWaypointPosition(_currentIndexPath);
        }

        _movement.RotateToPosition(_movePosition);
        _movement.MoveToPosition(_movePosition);
    }
}
