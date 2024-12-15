using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputComponent), typeof(ScoreComponent), typeof(SoundComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] InputComponent inputs;
    [SerializeField] List<DetectionComponent> detections;
    [SerializeField] ScoreComponent score;
    [SerializeField] SoundComponent sound;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI maxScoreText;
    [SerializeField] TextMeshProUGUI countText;
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
        sound = GetComponent<SoundComponent>();

        inputs.FirstLine.performed +=  detections[0].Detect;
        inputs.SecondLine.performed += detections[1].Detect;
        inputs.ThirdLine.performed += detections[2].Detect;
        InitAllEvent();
        countText.text = SpawnerManager.Instance.GameObjectCount.ToString();
        UpdateMaxScore(score.RetriveMaxScore());
    }

    void InitAllEvent()
    {
        int _size = detections.Count;
        for (int _i = 0; _i < _size; _i++)
        {
            detections[_i].OnHit += score.UpdateScore;
            detections[_i].OnHit += sound.PlaySound;
        }

        score.OnScoreChange += UpdateScoreValue;
        score.OnScoreChange += (_score) => UpdateScore();
        SpawnerManager.Instance.OnCountChanged += UpdateCountText;
    }

    void UpdateScoreValue(float _score)
    {
        Debug.Log(_score);
        slider.value = _score;
    }

    void UpdateMaxScore(float _score)
    {
        maxScoreText.text = "/ " + _score.ToString();
    }

    void UpdateScore()
    {
        scoreText.text = score.Score.ToString();
    }

    void UpdateCountText(int _count)
    {
        countText.text = _count.ToString();
    }
}