using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAttackInfo
{
    [SerializeField]
    private string m_Name;
    public string Name { get { return m_Name; } }

    [SerializeField]
    private string m_Button;
    public string Button { get { return m_Button;  } }

    [SerializeField]
    private string m_TriggerName;
    public string TriggerName { get { return m_TriggerName; } }

    [SerializeField]
    private GameObject m_AbilityGO;
    public GameObject AbilityGO { get { return m_AbilityGO; } }

    [SerializeField]
    private float m_WindupTime;
    public float WindupTime { get { return m_WindupTime; } }

    [SerializeField]
    private float m_FrozenTime;
    public float FrozenTime { get { return m_FrozenTime; } }

    [SerializeField]
    private float m_Cooldown;

    [SerializeField]
    private int m_HealthCost;
    public int HealthCost { get { return m_HealthCost; } }

    [SerializeField]
    private Color m_Color;
    public Color AbilityColor { get { return m_Color; } }

    public float Cooldown
    {
        get;
        set;
    }

    public void ResetCooldown()
    {
        Cooldown = m_Cooldown;
    }

    public bool IsReady()
    {
        return Cooldown <= 0;
    }
}
