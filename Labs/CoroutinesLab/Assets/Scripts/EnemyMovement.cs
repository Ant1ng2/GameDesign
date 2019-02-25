using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    bool moving;

	// Use this for initialization
	void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Don't use Update for this task
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Task 3: Start Your Coroutine Here
        if (!moving)
        {
            StartCoroutine(Checking(collision.gameObject.transform));
        }

    }

    // Task 3: Write Your Coroutine Here
    IEnumerator Checking(Transform mark)
    {
        moving = true;
        Vector2 position = transform.position;
        Vector2 final = mark.position;
        float time = 0.0f;

        while (time < 3.0f)
        {
            time += 0.02f;
            transform.position = Vector2.Lerp(position, final, time / 3.0f);
            yield return new WaitForSeconds(0.02f);
        }
        moving = false;
        yield return null;
    }
}
