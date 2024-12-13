using System.Threading;
using UnityEngine;

public abstract class MovingComponent : MonoBehaviour
{
    [SerializeField] [Range(0,5000)] protected float minMovementSpeed = 5.0f, maxMovementSpeed = 5.0f;
    [SerializeField] [Range(0,2)] protected float minDist = 2.0f; // min dist for IsAtLocaiton
    [SerializeField] protected float maxTimer = 5.0f; // maxTimer for curve

    protected float currentTimer = 0.0f;
    protected float rMoveSpeed = 0.0f;

    protected virtual void Start()
    {
        Init();
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
        if(currentTimer >= maxTimer) currentTimer = 0.0f;
    }

    private void OnDestroy()
    {
        //TO DO events on destroy
    }

    abstract public void Interpolate(); // Move By the Curve
}