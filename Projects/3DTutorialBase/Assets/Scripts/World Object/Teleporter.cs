using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform m_EndPoint;
    public Vector3 EndPoint
    {
        get { return m_EndPoint.position; }
    }
}
