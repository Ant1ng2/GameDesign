using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbility : Ability
{
    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private ParticleSystem m_DeathExplosion;

    #region Private Variables
    private Rigidbody cc_Rb;
    #endregion

    private void Awake()
    {
        cc_Rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().DecreaseHealth(Power);
        }

        ParticleSystem ps = Instantiate(m_DeathExplosion, transform.position, Quaternion.identity);
        Destroy(ps.gameObject, 3f);
        Destroy(gameObject, 0.1f);
    }

    public override void Use(Vector3 playerPos, Vector3 hitPos)
    {
        cc_Rb.velocity = transform.forward * m_Speed;
    }
}
