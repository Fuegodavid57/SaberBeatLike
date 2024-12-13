using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] MovingComponent movements = null;


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