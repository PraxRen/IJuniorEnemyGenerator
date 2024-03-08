using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Coroutine _jobMoveToDirection;

    private void OnDisable()
    {
        CancelMoveToDirection();
    }

    public void Move(Vector3 direction)
    {
        CancelMoveToDirection();
        _jobMoveToDirection = StartCoroutine(MoveToDirection(direction));
    }

    private IEnumerator MoveToDirection(Vector3 direction)
    {
        transform.LookAt(transform.position + direction.normalized, Vector3.up);

        while (true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            yield return null;
        }
    }

    private void CancelMoveToDirection()
    {
        if (_jobMoveToDirection != null)
            StopCoroutine(_jobMoveToDirection);
    }
}
