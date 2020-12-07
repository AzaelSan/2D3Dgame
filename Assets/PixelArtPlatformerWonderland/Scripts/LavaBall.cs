using UnityEngine;
using System.Collections;

public class LavaBall : MonoBehaviour
{
	// Jumping behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

	bool isGrounded;
	bool hasJumped;
	float timer;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		isGrounded = true;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		isGrounded = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isGrounded = false;
	}

	private void FixedUpdate()
	{
		timer += Time.deltaTime;

		if (timer > 3f && isGrounded && !hasJumped)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 300f));

			hasJumped = false;

			timer = 0f;
		}

		if (!isGrounded)
		{
			hasJumped = false;
		}
	}
}
