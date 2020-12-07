using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
	// Moving behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float timer;
    float direction = 1f;

	void FixedUpdate ()
    {
        if (timer < 5f)
        {
            transform.position += new Vector3(Time.deltaTime * direction, 0f, 0f);

            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            direction = -direction;
        }	
	}
}
