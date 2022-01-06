using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UI_Controller : MonoBehaviour
{
    public GameObject Pause;

    public void StartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Again()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }

    public void ExitButton()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
