using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class HideWall : MonoBehaviour
{
    #region
    [SerializeField]
    private float m_ShiftAmount;
    #endregion

    #region Private Variables
    private bool m_Shift;

    private Vector3 m_FinalPos;
    #endregion

    private void Awake()
    {
        m_Shift = false;
        m_FinalPos = transform.position + Vector3.down * m_ShiftAmount;
    }

    void Update()
    {
        if(m_Shift && transform.position.y > m_FinalPos.y)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        else if (transform.position.y <= m_FinalPos.y)
        {
            Destroy(gameObject);
        }
    }

    public void Shift()
    {
        m_Shift = true;
    }

}
