using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputComponent), typeof(ScoreComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] InputComponent inputs;
    [SerializeField] List<DetectionComponent> detections;
    [SerializeField] ScoreComponent score;
    [SerializeField] Slider slider;
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
        inputs.SecondLine.performed += detections[1].Detect;
        inputs.ThirdLine.performed += detections[2].Detect;
        InitAllEvent();
    }

    void InitAllEvent()
    {
        int _size = detections.Count;
        for (int _i = 0; _i < _size; _i++)
        {
            detections[_i].OnHit += score.UpdateScore;
        }

        score.OnScoreChange += UpdateScoreValue;
    }

    void UpdateScoreValue(float _score)
    {
        Debug.Log(_score);
        slider.value = _score;
    }
}