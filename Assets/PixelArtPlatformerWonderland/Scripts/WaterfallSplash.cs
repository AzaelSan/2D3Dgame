using UnityEngine;
using System.Collections;

public class WaterfallSplash : MonoBehaviour
{
	// Randomises start frame of waterfall slash for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

	void Start ()
    {
        GetComponent<Animator>().Play("WATERFALL_SPLASH", 0, Random.Range(0f, 0.9f));
        GetComponent<Animator>().speed = 2f;
	}

}
