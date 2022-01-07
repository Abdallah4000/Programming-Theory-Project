using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Menu : MonoBehaviour
{
    public TextMeshProUGUI EasyScoreText;
    public TextMeshProUGUI MediumScoreText;
    public TextMeshProUGUI HardScoreText;

    public void EasyButton()
    {
        DataSaver.instance.level = 0;
        DataSaver.instance.TScore = 0;
        DataSaver.instance.TScore2 = 0;

        
        Load();
    }
    public void MediumButton()
    {
        DataSaver.instance.level = 1;
        DataSaver.instance.TScore = 0;
        DataSaver.instance.TScore2 = 0;

        Load();
    }
    public void HardButton()
    {
        DataSaver.instance.level = 2;
        DataSaver.instance.TScore = 0;
        DataSaver.instance.TScore2 = 0;

        Load();
    }

    private void Load()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        DataSaver.instance.LoadScore();
    }

    public void ExitButton()
    {
        DataSaver.instance.SaveScore();
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    void Start()
    {
        AssignValues();
    }
    public void AssignValues()
    {
        DataSaver.instance.LoadScore();
        EasyScoreText.text = DataSaver.instance.EasyScore.ToString();
        MediumScoreText.text = DataSaver.instance.MediumScore.ToString();
        HardScoreText.text = DataSaver.instance.HardScore.ToString();

    }

}
