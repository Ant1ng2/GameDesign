using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CameraPitchControls : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Whether to inverse the mouse scroll or not. Default is drag up" +
        "to look up and drga down to look down.")]
    private bool m_InverseY;

    [SerializeField]
    [Tooltip("How quickly the player can pitch the camera up and down.")]
    private float m_PitchSpeed;

    [SerializeField]
    [Tooltip("The value at which the camera stops looking down. This is " +
        "based off of the transform which means it should be POSITIVE.")]
    private float m_MinPitchAngle;

    [SerializeField]
    [Tooltip("The value at which the camera stops looking up. This is " +
        "based off of the transform which means it should be NEGATIVE.")]
    private float m_MaxPitchAngle;
    #endregion

    #region Main Updates
    private void Update ()
    {
        float pitch = m_PitchSpeed * -Input.GetAxis("Mouse Y") * (m_InverseY ? -1 : 1);

        float angle = transform.eulerAngles.x;
        if (angle > 180)
            angle -= 360;
        if (angle - m_MinPitchAngle > -0.1f && pitch > 0)
        {
            transform.localRotation = Quaternion.Euler(m_MinPitchAngle, 0, 0);
            return;
        }
        if (angle - m_MaxPitchAngle < 0.1f && pitch < 0)
        {
            transform.localRotation = Quaternion.Euler(m_MaxPitchAngle, 0, 0);
            return;
        }
        transform.localRotation *= Quaternion.Euler(pitch, 0, 0);
	}
    #endregion
}
