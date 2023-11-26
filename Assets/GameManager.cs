using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Scene] private string _gameScene;
    [SerializeField, Scene] private string _creditScene;
    private float _score;

    public void ResetScore() => _score = 0;
    public void ScoreAdd(float value) => _score += value;
    public float GetScore() => _score;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_gameScene);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(_creditScene);
    }
}
