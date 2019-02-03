using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager singleton;

    #region Editor Variables
    [SerializeField]
    private Transform m_TutorialSpawnPoint;
    public Transform TutorialSpawnPoint
    {
        get { return m_TutorialSpawnPoint; }
    }

    [SerializeField]
    private Transform m_ArenaSpawnPoint;
    public Transform ArenaSpawnPoint
    {
        get { return m_ArenaSpawnPoint; }
    }
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
    }
}
