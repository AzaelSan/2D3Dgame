using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	// Spinning enemy behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    public float speed = -1000f;

	void FixedUpdate ()
    {
        transform.localEulerAngles += new Vector3(0f, 0f, Time.deltaTime * speed);
	}
}
