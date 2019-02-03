 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    #region Private Variables
    private int m_curScore;
    #endregion

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }

        m_curScore = 0;
    }

    private void OnDisable()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", m_curScore);
            return;
        }
        int hs = PlayerPrefs.GetInt("HS", m_curScore);
        if (hs < m_curScore)
        {
            PlayerPrefs.SetInt("HS", m_curScore);
        }
    }

    public void IncreaseScore(int amount)
    {
        m_curScore += amount;
        Debug.Log(m_curScore);
    }
}
