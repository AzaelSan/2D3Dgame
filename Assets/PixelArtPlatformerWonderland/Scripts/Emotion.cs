using UnityEngine;
using System.Collections;

public class Emotion : MonoBehaviour
{
	// Character-tracking emote for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

	public GameObject Character;

	void FixedUpdate ()
	{
		Vector3 myPosition = transform.position;
		myPosition.x = Character.transform.position.x;
		transform.position = myPosition;
	}
}
