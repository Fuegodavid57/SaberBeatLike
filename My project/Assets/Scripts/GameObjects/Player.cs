using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] InputComponent inputs;
    [SerializeField] List<DetectionComponent> detections;
    [SerializeField] ScoreComponent score;
    void Start()
    {
        Init();
    }

    void Update()
    {
    }

    void Init()
    {
        inputs = GetComponent<InputComponent>();
        score = GetComponent<ScoreComponent>();

        inputs.FirstLine.performed +=  detections[0].Detect;
        //inputs.SecondLine.performed += detections[1].Detect;
        //inputs.ThirdLine.performed += detections[2].Detect;
    }
}