using UnityEngine;
using System.Collections;

public class Ninja : MonoBehaviour
{
	// Player-controlled platform game character behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

	bool isJumping = false;

	float direction = 1f;

	bool isGrounded;
	bool wasGrounded;

	Animator animator;
	Rigidbody2D body;

	public float runSpeed = 200000f;
	public float jumpPower = 480000f;
	public float jumpLength = 0.2f;
	public float jumpTimer = 0f;

	public Explosion landingDustPrefab;
	public GameObject waterSplashPrefab;
	public GameObject waterSplash;

	public bool isInWater;

	private void Awake()
	{
		body = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		waterSplash = Instantiate<GameObject> (waterSplashPrefab);
		waterSplash.transform.parent = transform;
		waterSplash.transform.localPosition = new Vector3 (0f, 0.25f);
	}

	private void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.DownArrow))
		{
			animator.SetBool("IsDucking", true);
		} 
		else
		{
			body.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * Time.deltaTime * runSpeed, 0f));

			animator.SetBool("IsDucking", false);
		}

		if (Mathf.Abs (body.velocity.x) > 0.02f && isInWater)
		{
			waterSplash.SetActive (true);
		}
		else
		{
			waterSplash.SetActive (false);
		}

		if (isGrounded) 
		{
			isJumping = false;
			jumpTimer = 0f;

			if (!wasGrounded) 
			{
				Explosion landingDust = Instantiate<Explosion> (landingDustPrefab);
				landingDust.transform.position = transform.position;
			}
		}

		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			if (isGrounded)
			{
				isJumping = true;

				body.velocity = new Vector2 (body.velocity.x, 0f);

				animator.SetTrigger("Jump");
			}
		}

		if (isJumping && jumpTimer <= jumpLength)
		{
			body.AddForce(new Vector2 (0f, jumpPower));

			jumpTimer += Time.deltaTime;
		}

		if (Mathf.Abs (body.velocity.x) > 0.1f)
		{
			animator.SetBool("IsWalking", true);
		} 
		else 
		{
			animator.SetBool("IsWalking", false);
		}

		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			animator.SetTrigger("Fire");
		}

		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > 0.1f) 
		{
			if (Input.GetAxis ("Horizontal") < 0f) 
			{
				direction = -1f;
			} 
			else 
			{
				direction = 1f;
			}
		}

		transform.localScale = new Vector3(direction, 1f, 1f);

		animator.SetBool ("IsGrounded", isGrounded);

		wasGrounded = isGrounded;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		isGrounded = true;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		isGrounded = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		isGrounded = false;
	}

}
