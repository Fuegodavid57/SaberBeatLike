using UnityEngine;

public abstract class MovingComponent : MonoBehaviour
{
    [SerializeField] [Range(0,5000)] protected float movementSpeed = 5.0f;
    [SerializeField] protected Vector3 backPos = Vector3.zero, frontPos = Vector3.zero; //Positions To Check
    [SerializeField] protected Vector3 targetPos = Vector3.zero; // Location To Go and detroy if reach it
    [SerializeField] [Range(0,2)] protected float minDist = 2.0f; // min dist for IsAtLocaiton
    [SerializeField] protected AnimationCurve speedCurve; // CurveMoving

    public Vector3 BackPos => backPos;
    public Vector3 FrontPos => frontPos;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        Interpolate();
    }

    protected virtual void Init()
    {
    }

    /// <summary>
    /// if the object is at his final location detroys it and lose some score
    /// </summary>
    protected virtual void DetroyWhenAtLocation()
    {
        //TODO INVOKE LOSE POINTS EVENT FROM MOVING OBJECTS MANAGER
    }

    /// <summary>
    /// Checks if the object is at the final location
    /// </summary>
    /// <returns></returns>
    protected virtual bool IsAtTargetLocation()
    {
        if (Vector3.Distance(transform.position, targetPos) <= minDist) return true;
        return false;
    }

    abstract public void Interpolate(); // Move By the Curve
}