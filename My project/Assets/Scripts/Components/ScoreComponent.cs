using System;
using UnityEngine;

public class ScoreComponent : MonoBehaviour
{
    public event Action<float> OnScoreChange;
    [SerializeField] float score = 0;
    [SerializeField] float maxScore = 0;
    [SerializeField] float perfectScore = 500.0f;
    [SerializeField] float averageScore = 100.0f;
    [SerializeField] float missScore = 50.0f;
    void Start()
    {
        Init();
    }
    void Init()
    {
        RetriveMaxScore();
    }

    public void UpdateScore(HIT_TYPE _hit)
    {
        if(_hit == HIT_TYPE.PERFECT) AddScore(true);
        else if(_hit == HIT_TYPE.AVERAGE)  AddScore();
        else RemoveScore();
    }
    void AddScore(bool _isPerfect = false)
    {
        score += _isPerfect ? perfectScore : averageScore;
        OnScoreChange?.Invoke(score * 100 / maxScore);
    }

    void RemoveScore()
    {
        score -= missScore;
        score = score < 0 ? 0 : score;
        OnScoreChange?.Invoke(score * 100 / maxScore);
    }

    void RetriveMaxScore()
    {
        int _gameObjectCount = SpawnerManager.Instance.GameObjectCount;
        maxScore = _gameObjectCount * perfectScore;
    }
}