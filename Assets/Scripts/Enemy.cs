using System;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Enemy : MonoBehaviour
{
    private Movement _movement;
    private Transform _transformTarget;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        FollowTarget();
    }

    public void SetTarget(Transform target)
    {
        if (target == null)
            throw new ArgumentNullException(nameof(target));

        _transformTarget = target;
    }

    private void FollowTarget()
    {
        if (_transformTarget == null)
            return;

        _movement.RotateToPosition(_transformTarget.position);
        _movement.MoveToPosition(_transformTarget.position);
    }
}
