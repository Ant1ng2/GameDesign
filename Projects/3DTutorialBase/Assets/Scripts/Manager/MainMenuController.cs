using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Text m_HighScore;

    private string m_DefaultHighScoreText;

    private void Awake()
    {
        m_DefaultHighScoreText = m_HighScore.text;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_HighScore.text = m_DefaultHighScoreText.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS", 0);
            m_HighScore.text = m_DefaultHighScoreText.Replace("%S", "0");
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        UpdateHighScore();
    }

    public void PlayTutorial()
    {
        GameManager.singleton.PrepareTutorial();
        SceneManager.LoadScene("TutorialAndArena");
    }

    public void PlayArena()
    {
        GameManager.singleton.PrepareArena();
        SceneManager.LoadScene("TutorialAndArena");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
