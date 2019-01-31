using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ConfigurableJoint))]
public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("How fast the player moves around.")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("How strong the player's jumping is.")]
    private float m_JumpStrength;

    [SerializeField]
    [Tooltip("How fast the player rotates.")]
    private float m_RotationSpeed;
    #endregion

    #region Private Variables
    private Vector2 p_Velocity;

    private bool p_isJumping;

    private float p_RotationAmount;
    #endregion

    #region Cached Components
    private Rigidbody cc_Rb;

    private ConfigurableJoint cc_Spring;
    #endregion

    #region Initalization
    private void Awake()
    {
        p_Velocity = Vector2.zero;
        p_isJumping = false;
        p_RotationAmount = 0;

        cc_Rb = GetComponent<Rigidbody>();
        cc_Spring = GetComponent<ConfigurableJoint>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100, 1 << LayerMask.NameToLayer("Floor")))
        {
            cc_Spring.targetPosition = new Vector3(0, -hit.point.y, 0);
            if (p_isJumping && Mathf.Abs(transform.position.y - hit.point.y) < 1.05f)
                p_isJumping = false;
        }
        else
            cc_Spring.targetPosition = new Vector3(0, 100, 0);

        float forward = Input.GetAxisRaw("Vertical");
        float right = Input.GetAxisRaw("Horizontal");

        p_Velocity.Set(right, forward);
        p_Velocity.Normalize();

        if (Input.GetButtonDown("Jump") && !p_isJumping)
        {
            cc_Rb.AddForce(Vector3.up * m_JumpStrength, ForceMode.Impulse);
            p_isJumping = true;
        }

        p_RotationAmount = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        Vector3 dir = transform.forward * p_Velocity.y + transform.right * p_Velocity.x;
        cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);

        cc_Rb.angularVelocity = Vector3.zero;
        cc_Rb.MoveRotation(cc_Rb.rotation * Quaternion.Euler(0, m_RotationSpeed * p_RotationAmount, 0));
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
}

