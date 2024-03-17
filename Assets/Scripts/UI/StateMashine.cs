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

    [Header("Windows")]
    [SerializeField] private Window _gameScreen;
    [SerializeField] private Window _looseGameScreen;
    [SerializeField] private Window _pauseGameScreen;
    [SerializeField] private Window _menuGameScreen;
    [SerializeField] private Window _winLevelScreen;

    private Window _currentScreen;

    private void Start()
    {
        _currentScreen = _gameScreen;
    }

    public void ChangeStates(StateType state)
    {
        if (_currentScreen == null)
        {
            return;
        }
        _currentScreen.Close_Instantly();

        switch (state)
            {
           
            case StateType.game:
                _gameScreen.Open_Instantly();
                _currentScreen = _gameScreen;
                break;
            case StateType.looseGame:
                _looseGameScreen.Open_Instantly();
                _currentScreen = _looseGameScreen;
                break;
            case StateType.winLevel:
                _winLevelScreen.Open_Instantly();
                _currentScreen = _winLevelScreen;
                break;
            case StateType.pause:
                _pauseGameScreen.Open_Instantly();
                _currentScreen = _pauseGameScreen;
                break;
            case StateType.menu:
                _menuGameScreen.Open_Instantly();
                _currentScreen = _menuGameScreen;
                break;
        }

    }
}
