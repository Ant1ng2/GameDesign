using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class HUD : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private RectTransform m_HealthBar;
    #endregion

    #region Private Variable
    private float m_HealthBarOrigWidth;
    #endregion

    #region Intialization
    private void Awake()
    {
        m_HealthBarOrigWidth = m_HealthBar.sizeDelta.x;
    }
    #endregion

    public void UpdateHealth(float percent)
    {
        m_HealthBar.sizeDelta = new Vector2(m_HealthBarOrigWidth * percent, m_HealthBar.sizeDelta.y);
    }
}
