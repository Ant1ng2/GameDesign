using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int m_MaxHealth;

    [SerializeField]
    [Tooltip("How quickly the enemy will move around.")]
    private float m_Speed;

    [SerializeField]
    private float m_Damage;
    #endregion

    #region Private Variables
    private float p_CurHealth;
    #endregion

    #region Cached Components
    private Rigidbody cc_Rb;
    #endregion

    #region Cached References
    private Transform cr_Player;
    #endregion

    #region Initialization
    private void Awake()
    {
        cc_Rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        cr_Player = FindObjectOfType<PlayerController>().transform;
    }
    #endregion

    #region Main Updates
    private void FixedUpdate()
    {
        Vector3 dir = cr_Player.position - transform.position;
        dir.Normalize();
        cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
    }
    #endregion

    #region Collision Methods
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Player"))
            other.GetComponentInParent<PlayerController>().DecreaseHealth(m_Damage);
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        Destroy(gameObject);
    }
    #endregion
}
