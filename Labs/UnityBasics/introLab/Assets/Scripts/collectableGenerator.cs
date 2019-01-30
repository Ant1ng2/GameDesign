using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectableGenerator : MonoBehaviour
{
    public GameObject pellet;
    
    void Start()
    {
        for (int i = 0; i < 300; i++)
        {
            Instantiate(pellet, new Vector3((Random.value - 0.5f) * 61.0f, (Random.value - 0.5f) * 29.0f, 0), Quaternion.identity);
        }
    }
}
