using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{

    public void RestartGame()
    {
        LoadScence(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadNextScence()
    {
        LoadScence(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScence(int level)
    {
        SceneManager.LoadScene(level);
    }

    public int GetActiveScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
