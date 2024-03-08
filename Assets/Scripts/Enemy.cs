using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Enemy : MonoBehaviour
{
    public Movement Movement { get; private set; }

    private void Awake()
    {
        Movement = GetComponent<Movement>();
    }
}
