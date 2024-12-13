using System;
using UnityEngine;

public class CircEaseOutComponent : MovingComponent
{
    override protected void Start()
    {
        base.Start();
        Init();
    }

    override protected void Update()
    {
        base.Update();
    }

    override protected void Init()
    {
        base.Init();
    }

    public override void Interpolate()
    {
        //return Math.sqrt(1 - Math.pow(x - 1, 2));
        float _t = Mathf.Clamp01(currentTimer / maxTimer);
        float _eased = Mathf.Sqrt(1 - Mathf.Pow(_t - 1, 2)); ;
        float _newSpeed = rMoveSpeed + _eased;
        Vector3 _nextPos = transform.forward * _newSpeed;
        Debug.Log(_newSpeed);

        transform.position +=new Vector3(_nextPos.x,0, _nextPos.z) ;

    }
}