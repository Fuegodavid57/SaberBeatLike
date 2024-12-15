using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum HIT_TYPE
{
    PERFECT,
    AVERAGE,
    MISS
};

public class DetectionComponent : MonoBehaviour
{
    public event Action<HIT_TYPE> OnHit;
    [SerializeField] Vector3 size = new Vector3(1, 1, 1);
    [SerializeField] float minDistPerfect = 0.2f, minDistAverage = 0.5f;
    [SerializeField] LayerMask mask;

    void Start()
    {
        Init();
    }

    void Update()
    {
    }

    void Init()
    {
    }

    public void Detect(InputAction.CallbackContext _context)
    {
        RaycastHit[] _perfecthits = Physics.BoxCastAll(transform.position, size, transform.up, transform.rotation, mask);
        if(_perfecthits.Length == 0 )
        {
            OnHit?.Invoke(HIT_TYPE.MISS);
        }
        Check(_perfecthits);
    }


    void Check(RaycastHit[] _hits)
    {
        int _size = _hits.Length;
        for (int _i = 0; _i < _size; _i++)
        {
            HIT_TYPE _type = DistanceCheck(_hits[_i].transform.position, minDistPerfect) ? HIT_TYPE.PERFECT :
                DistanceCheck(_hits[_i].transform.position, minDistAverage) ? HIT_TYPE.AVERAGE : HIT_TYPE.MISS;

            if (_type != HIT_TYPE.MISS)
            {
                Destroy(_hits[_i].collider.gameObject);
            }
            OnHit?.Invoke(_type);
        }
    }

    bool DistanceCheck(Vector3 _pos, float _dist)
    {
        return Vector3.Distance(transform.position, _pos) <= _dist;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, transform.position + transform.forward * minDistAverage);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, size);
        ////Gizmos.DrawLine(transform.position, transform.position + transform.forward * minDistPerfect);
        //Gizmos.DrawWireSphere(transform.position, minDistPerfect);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, minDistAverage);
    }
}