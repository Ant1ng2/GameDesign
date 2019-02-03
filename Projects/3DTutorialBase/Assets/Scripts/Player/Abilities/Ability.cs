using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    protected AbilityInfo m_Info;

    protected ParticleSystem cc_PS;

    private void Awake()
    {
        cc_PS = GetComponent<ParticleSystem>();
        Destroy(gameObject, 15);
    }

    public abstract void Use(Vector3 playerPos, Vector3 hitPos);

    public float Range { get { return m_Info.Range; } }

    public int Power { get { return m_Info.Power; } }
}
