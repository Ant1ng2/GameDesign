using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private HideWall m_Wall;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("AttackAbility"))
        {
            return;
        }

        if (m_Wall != null)
        {
            m_Wall.Shift();
        }

        Destroy(gameObject);
    }
}
