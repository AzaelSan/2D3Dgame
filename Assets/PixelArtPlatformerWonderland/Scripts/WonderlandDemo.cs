using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WonderlandDemo : MonoBehaviour
{
	// Arrow-key controlled camera behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

	public float panSpeedX = 2f;
	public float panSpeedY = 2f;
	public float maxX = 100f;
	public float minX = -100f;
	public float maxY = 100f;
	public float minY = -100f;

    private void Awake()
    {
        Camera.main.transparencySortMode = TransparencySortMode.Orthographic;
    }
		
	void Update ()
    {
        Camera cam = Camera.main;

		Vector3 position = cam.transform.position;

		position += (new Vector3(Input.GetAxis("Horizontal") * panSpeedX, Input.GetAxis("Vertical") * panSpeedY, 0f) * Time.deltaTime);

		if (position.x < minX)
		{
			position.x = minX;
		}
		if (position.x > maxX)
		{
			position.x = maxX;
		}
		if (position.y < minY)
		{
			position.y = minY;
		}
		if (position.y > maxY) 
		{
			position.y = maxY;
		}

		cam.transform.position = position;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("DemoMenu");
        }
    }
}
