using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	// Timed self-destructing explosion for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float timer;
	public bool loop;

	void FixedUpdate ()
    {
        timer += Time.deltaTime;

        if (timer > 0.4f)
        {
			if (!loop)
			{
				Destroy (gameObject);
			}
        }
	}
}
