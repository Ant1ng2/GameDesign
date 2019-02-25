using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D playerRigidbody;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        playerRigidbody.velocity = movement * 2;

        if(Input.GetKeyDown(KeyCode.F)) {
            // Task 1: Start Your Coroutine Here
            StartCoroutine(Fade());
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall") {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    // Task 1: Write Your Coroutine Here
    IEnumerator Fade()
    {
        float i = 0.0f;
        Color color = GetComponent<SpriteRenderer>().color;
        while (GetComponent<SpriteRenderer>().color != Color.black)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(color, Color.black, i);
            i += Time.deltaTime;
            yield return null;
        }
    }
}