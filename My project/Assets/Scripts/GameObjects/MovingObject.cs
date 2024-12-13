using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] MovingComponent movements = null;
    [SerializeField] protected Vector3 backPos = Vector3.zero, frontPos = Vector3.zero; //Positions To Check
    public Vector3 BackPos => backPos;
    public Vector3 FrontPos => frontPos;

    public MovingComponent MovingComponent => movements;

    void Start()
    {
        Init();
    }

    void Update()
    {

    }

    void Init()
    {
        movements = GetComponent<MovingComponent>(); 
    }
}