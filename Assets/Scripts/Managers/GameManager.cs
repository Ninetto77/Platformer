using System.Collections;
using UnityEngine;

using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    #region Singlton
    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);
    }
    #endregion

    static public int CountDeadEnemy;
    [SerializeField] private PlayerInput playerInput;

    private float bonuses;
    private StateMashine _stateMashine;
    private MySceneManager _sceneManager;

    //[Header("Windows")]
    //[SerializeField] private Window _gameScreen;
    //[SerializeField] private Window _looseGameScreen;
    //[SerializeField] private Window _pauseGameScreen;
    //[SerializeField] private Window _menuGameScreen;
    //[SerializeField] private Window _winLevelScreen;

    void Start()
    {
        _stateMashine = GetComponent<StateMashine>();
        _sceneManager = GetComponent<MySceneManager>();
        CheckForLevel();
        PlayGame();
    }

    private void CheckForLevel()
    {
        if (_sceneManager.GetActiveScene() == 0)
        {
            StartCoroutine(WaitForFinishCutscene());
        }
    }

    private IEnumerator WaitForFinishCutscene()
    {
        playerInput.enabled = false;
        yield return new WaitForSeconds(10f);
        playerInput.enabled = true;

    }

    public void SetSliderValue(float value)
    {
        UIManager.Instance.ChangeSliderValue(value);
        
    }
    public void SetBonusValue(float value)
    {
        UIManager.Instance.ChangeBonusValue(value);
        bonuses = value;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        _stateMashine.ChangeStates(StateMashine.StateType.game);
    }


    public void LooseGame()
    {
        StartCoroutine(WaitForDead());
    }

    private IEnumerator WaitForDead()
    {
        playerInput.enabled = false;
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        _stateMashine.ChangeStates(StateMashine.StateType.looseGame);
    }

    public void Menu()
    {
        _stateMashine.ChangeStates(StateMashine.StateType.menu);
    }
    public void Pause()
    {
        _stateMashine.ChangeStates(StateMashine.StateType.pause);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        _sceneManager.RestartGame();
        //LoadScence(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScence()
    {
        _sceneManager.LoadNextScence();
        //LoadScence(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScence(int level)
    {
        _sceneManager.LoadScence(level);
        //SceneManager.LoadScene(level);
    }

    internal void FinishLevel()
    {
        StartCoroutine(WaitForFinishLevel());
    }

    private IEnumerator WaitForFinishLevel()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        UIManager.Instance.ChangeWinBonusValue(bonuses, CountDeadEnemy);
        _stateMashine.ChangeStates(StateMashine.StateType.winLevel);
    }
}
