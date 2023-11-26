using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField, Scene] private string _gameScene;
    [SerializeField, Scene] private string _creditScene;
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
