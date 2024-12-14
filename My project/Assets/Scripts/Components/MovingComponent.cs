using System.Threading;
using UnityEngine;

public abstract class MovingComponent : MonoBehaviour
{
    [SerializeField][Range(0, 5000)] protected float minMovementSpeed = 1.0f, maxMovementSpeed = 5.0f;
    [SerializeField] protected float maxTimer = 5.0f; // maxTimer for curve
    [SerializeField] protected Vector3 movingDir = Vector3.forward; // maxTimer for curve

    protected float currentTimer = 0.0f;
    protected float rMoveSpeed = 0.0f;

    protected virtual void Start()
    {
        Init();
        Destroy(gameObject, maxTimer);
    }

    protected virtual void Update()
    {
        Interpolate();
        UpdateTime();
    }

    protected virtual void Init()
    {
        RandomizeMovementSpeed();
    }

    void RandomizeMovementSpeed()
    {
        rMoveSpeed = UnityEngine.Random.Range(minMovementSpeed, maxMovementSpeed);
    }

    protected virtual void UpdateTime()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= maxTimer) currentTimer = 0.0f;
    }

    abstract public void Interpolate(); // Move By the Curve
}