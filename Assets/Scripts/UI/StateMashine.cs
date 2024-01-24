using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMashine : MonoBehaviour
{
    [HideInInspector]
    public enum StateType
    {
        game,
        looseGame,
        winLevel,
        pause, 
        menu
    }

    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _looseGameScreen;
    [SerializeField] private GameObject _pauseGameScreen;
    [SerializeField] private GameObject _menuGameScreen;
    [SerializeField] private GameObject _winLevelScreen;
    private GameObject _currentScreen;
    void Start()
    {
        _gameScreen.SetActive(true);
        _looseGameScreen.SetActive(false);
        _pauseGameScreen.SetActive(false);
        _menuGameScreen.SetActive(false);
        _winLevelScreen.SetActive(false);
        _currentScreen = _gameScreen;
    }

    public void ChangeStates(StateType state)
    {
        if (_currentScreen == null)
        {
            return;
        }
        _currentScreen.SetActive(false);

        switch(state)
            {
           
            case StateType.game:
                _gameScreen.SetActive(true);
                _currentScreen = _gameScreen;
                break;
            case StateType.looseGame:
                _looseGameScreen.SetActive(true);
                _currentScreen = _looseGameScreen;
                break;
            case StateType.winLevel:
                _winLevelScreen.SetActive(true);
                _currentScreen = _winLevelScreen;
                break;
            case StateType.pause:
                _pauseGameScreen.SetActive(true);
                _currentScreen = _pauseGameScreen;
                break;
            case StateType.menu:
                _menuGameScreen.SetActive(true);
                _currentScreen = _menuGameScreen;
                break;
        }

    }
}
