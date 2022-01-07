using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class UI_Controller : MonoBehaviour
{
    public GameObject Pause;

    public TextMeshProUGUI Score;// in the game
    public TextMeshProUGUI Score1;// in pause screen
    public TextMeshProUGUI Score2;// high score

    private void Update() {

        DataCheck();
        AssignS();

        Score.text = DataSaver.instance.TScore.ToString();
        Score1.text = DataSaver.instance.TScore2.ToString();

    }

    private void AssignS()
    {
        if(DataSaver.instance.level == 0)
        {
            Score2.text = DataSaver.instance.EasyScore.ToString();
        }
        if(DataSaver.instance.level == 1)
        {
            Score2.text = DataSaver.instance.MediumScore.ToString();

        }
        if(DataSaver.instance.level == 2)
        {
            Score2.text = DataSaver.instance.HardScore.ToString();

        }        
    }

    public void Again()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        DataSaver.instance.TScore = 0;
        DataSaver.instance.TScore2 = 0;

    }

    public void MenuButton()
    {
        DataCheck();
        SceneManager.LoadScene(0);
        DataSaver.instance.TScore = 0;
        DataSaver.instance.TScore2 = 0;

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
        DataCheck();
        DataSaver.instance.SaveScore();

        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    private void DataCheck()
    {
        if(DataSaver.instance.level==0)
        {
            if(DataSaver.instance.TScore > DataSaver.instance.EasyScore)
            {
                DataSaver.instance.EasyScore = DataSaver.instance.TScore;
                DataSaver.instance.SaveScore();
            }
        }
        else if(DataSaver.instance.level==1)
        {
            if(DataSaver.instance.TScore > DataSaver.instance.MediumScore)
            {
                DataSaver.instance.MediumScore = DataSaver.instance.TScore;
                DataSaver.instance.SaveScore();
            }
        }
        else if(DataSaver.instance.level==2)
        {
            if(DataSaver.instance.TScore > DataSaver.instance.HardScore)
            {
                DataSaver.instance.HardScore = DataSaver.instance.TScore;
                DataSaver.instance.SaveScore();
            }
        }
    }
}
