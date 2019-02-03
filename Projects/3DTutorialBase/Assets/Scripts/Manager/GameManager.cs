using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    #region Private Variables
    private bool m_PrepareTutorial;

    private bool m_GameStarted;
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

        DontDestroyOnLoad(this);

        m_PrepareTutorial = false;
    }

    private void Update()
    {
        if (!m_GameStarted)
        {
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            return;
        }

        if (m_PrepareTutorial)
        {
            player.transform.position = PlayerSpawnManager.singleton.TutorialSpawnPoint.position;
        }
        else
        {
            player.transform.position = PlayerSpawnManager.singleton.ArenaSpawnPoint.position;
        }
        m_GameStarted = false;
    }

    public void PrepareTutorial()
    {
        m_PrepareTutorial = true;
        m_GameStarted = true;
    }

    public void PrepareArena()
    {
        m_PrepareTutorial = false;
        m_GameStarted = true;
    }
}
