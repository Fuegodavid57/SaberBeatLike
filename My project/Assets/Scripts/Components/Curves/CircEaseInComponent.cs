using TreeEditor;
using UnityEngine;

public class CircEaseInComponent : MovingComponent
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
        float _t = Mathf.Clamp01(currentTimer / maxTimer);
        float _eased = 1 - Mathf.Sqrt(1 - Mathf.Pow(_t, 2));

        Vector3 _nextPos = movingDir * rMoveSpeed * _eased * Time.deltaTime;

        transform.position += new Vector3(_nextPos.x, 0, _nextPos.z);

    }
}