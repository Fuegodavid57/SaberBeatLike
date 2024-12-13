using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DetectionComponent : MonoBehaviour
{
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
        Check(_perfecthits);
    }


    void Check(RaycastHit[] _hits)
    {
        int _size = _hits.Length;
        for (int _i = 0; _i < _size; _i++)
        {
            if (DistanceCheck(_hits[_i].transform.position, minDistPerfect))
            {
                Debug.Log("perfect hit");
            }
            else if (DistanceCheck(_hits[_i].transform.position, minDistAverage))
            {
                Debug.Log("average hit");
            }
        }
    }

    bool DistanceCheck(Vector3 _pos, float _dist)
    {
        return Vector3.Distance(transform.position, _pos) <= _dist;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * minDistAverage);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * minDistPerfect);
    }
}