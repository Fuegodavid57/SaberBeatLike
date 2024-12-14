using UnityEngine;

public class CircEaseInOutComponent : MovingComponent
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
        /*
          Formule : 
          return x < 0.5
          ? (1 - Math.sqrt(1 - Math.pow(2 * x, 2))) / 2
          : (Math.sqrt(1 - Math.pow(-2 * x + 2, 2)) + 1) / 2; 
         */

        float _t = Mathf.Clamp01(currentTimer / maxTimer);
        float _eased = _t < 0.5f ?
            (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * _t, 2))) / 2 :
            (Mathf.Sqrt(1 - Mathf.Pow(-2 * _t + 2, 2)) + 1) / 2;

        Vector3 _nextPos = movingDir * rMoveSpeed * _eased * Time.deltaTime;
        transform.position += new Vector3(_nextPos.x, 0, _nextPos.z);
    }
}