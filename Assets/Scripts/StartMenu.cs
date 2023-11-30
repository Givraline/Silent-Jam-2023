using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    public void StartGame()
    {
        _gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
