using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DemoMenuButton : MonoBehaviour
{
	// Naivigation button for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    public string sceneName;

    private void OnMouseDown()
    {
        if (sceneName != "")
        {
			SceneManager.LoadScene(sceneName);
        }
    }
}
