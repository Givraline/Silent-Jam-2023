using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private RectTransform _creditMenu;
    private RectTransform canvasTransform;
    private GameManager _gameManager;
    private float posYTarget;
    [SerializeField, Scene] private int _mainMenuScene;
    void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        canvasTransform = GetComponent<RectTransform>();
        posYTarget = _creditMenu.position.y + _creditMenu.sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        _creditMenu.position = Vector3.MoveTowards(_creditMenu.position, new Vector3(_creditMenu.position.x, posYTarget, _creditMenu.position.z), Time.deltaTime * 50 * canvasTransform.localScale.y);
    }

    public void RestartGame()
    {
        _gameManager.ResetScore();
        SceneManager.LoadScene(_mainMenuScene);
    }
}
