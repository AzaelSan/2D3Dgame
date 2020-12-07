using UnityEngine;
using System.Collections;

public class DemoMainMenu : MonoBehaviour
{
	// Main menu for navigating Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
