using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int m_MaxHealth = 3;

    [SerializeField]
    [Tooltip("How quickly the enemy will move around.")]
    private float m_Speed;

    [SerializeField]
    private float m_Damage;

    [SerializeField]
    private GameObject m_HealthPill;

    [SerializeField]
    private float m_HealthPillDropRate;

    [SerializeField]
    private int m_Score;
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
        p_CurHealth = m_MaxHealth;
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
        p_CurHealth -= amount;
        if (p_CurHealth <= 0)
        {
            if (Random.value < m_HealthPillDropRate)
            {
                Instantiate(m_HealthPill, transform.position, Quaternion.identity);
            }
            ScoreManager.singleton.IncreaseScore(m_Score);
            Destroy(gameObject);
        }
    }
    #endregion
}
