using UnityEngine;
using System.Collections;

public class SplashZone : MonoBehaviour
{
	// Water-splash behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

	void OnTriggerEnter2D(Collider2D other)
	{
		Ninja myNinja = other.GetComponent<Ninja> ();
		if (myNinja != null) 
		{
			myNinja.isInWater = true;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Ninja myNinja = other.GetComponent<Ninja> ();
		if (myNinja != null)
		{
			myNinja.isInWater = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Ninja myNinja = other.GetComponent<Ninja> ();
		if (myNinja != null)
		{
			myNinja.isInWater = false;
		}
	}
}
