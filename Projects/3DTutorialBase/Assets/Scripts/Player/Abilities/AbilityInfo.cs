using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInfo
{
    [SerializeField]
    private int m_Power;
    public int Power { get { return m_Power; } }

    [SerializeField]
    private float m_Range;
    public float Range { get { return m_Range; } }
}
