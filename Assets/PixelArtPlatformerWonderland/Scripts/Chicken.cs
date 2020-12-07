using UnityEngine;
using System.Collections;

public class Chicken : MonoBehaviour
{
	// Wandering chicken behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float timer = 0f;
    float direction = 1f;
	Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator> ();
	}

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer < 3f)
        {
			animator.SetBool("IsWalking", false);
        }
        else if (timer < 4f)
        {
			animator.SetBool("IsWalking", true);

            transform.position += new Vector3(Time.deltaTime * 2f * direction, 0f, 0f);
        }
        else
        {
            direction = -direction;
            timer = 0f;

            transform.localScale = new Vector3(direction, 1f, 1f);
        }

    }
}
