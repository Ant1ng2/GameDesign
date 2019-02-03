using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ArenaStart : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner m_Spawner;

    public EnemySpawner Spawner
    {
        get { return m_Spawner; }
    }
}
