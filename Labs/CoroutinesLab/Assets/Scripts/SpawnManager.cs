using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject sentry;
    public Transform[] spawnPositions;

	// Use this for initialization
	void Start () {
        // Task 2: Start Your Coroutine Here
        StartCoroutine(Spawning());
    }
	
	// Update is called once per frame
	void Update () {
        // Don't use Update for this task!
    }

    // Task 2: Write Your Coroutine Here
    IEnumerator Spawning()
    {
        while (true)
        {
            foreach (Transform position in spawnPositions)
            {
                Instantiate(sentry, position);
                yield return null;
            }
            yield return new WaitForSeconds(20);
        }
    }
}
